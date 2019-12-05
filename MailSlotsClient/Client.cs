using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace MailSlots
{
    public partial class frmMain : Form
    {
        private Int32 HandleMailSlot;                   // дескриптор мэйлслота
        private Int32 HandleClientMailSlot;             // дескриптор приёмного мэйлслота
        private Thread t;
        private bool _continue = true;
        private bool _connected = false;
        // конструктор формы
        public frmMain()
        {
            InitializeComponent();
            this.Text += "     " + Dns.GetHostName();   // выводим имя текущей машины в заголовок формы
            HandleClientMailSlot = DIS.Import.CreateMailslot("\\\\.\\mailslot\\ClientMailslot", 0, DIS.Types.MAILSLOT_WAIT_FOREVER, 0);
            t = new Thread(ReceiveMessage);
            t.Start();
        }

        private void ReceiveMessage()
        {
            string msg = "";            // прочитанное сообщение
            int MailslotSize = 0;       // максимальный размер сообщения
            int lpNextSize = 0;         // размер следующего сообщения
            int MessageCount = 0;       // количество сообщений в мэйлслоте
            uint realBytesReaded = 0;   // количество реально прочитанных из мэйлслота байтов

            // входим в бесконечный цикл работы с мэйлслотом
            while (_continue)
            {
                DIS.Import.GetMailslotInfo(HandleClientMailSlot, MailslotSize, ref lpNextSize, ref MessageCount, 0);

                // если есть сообщения в мэйлслоте, то обрабатываем каждое из них
                if (MessageCount > 0)
                {
                    for (int i = 0; i < MessageCount; i++)
                    {
                        byte[] buff = new byte[1024];
                        DIS.Import.FlushFileBuffers(HandleClientMailSlot);      // "принудительная" запись данных, расположенные в буфере операционной системы, в файл мэйлслота
                        DIS.Import.ReadFile(HandleClientMailSlot, buff, 1024, ref realBytesReaded, 0);      // считываем последовательность байтов из мэйлслота в буфер buff
                        msg = Encoding.Unicode.GetString(buff);                 // выполняем преобразование байтов в последовательность символов
                        int lastIdx = msg.IndexOf('\0');
                        if (lastIdx != -1)
                            msg = msg.Substring(0, lastIdx);
                        if (_connected)
                        {
                            tb_messages.Invoke((MethodInvoker)delegate
                            {
                                if (msg != "")
                                    tb_messages.Text += "\n >> " + msg + " \n";     // выводим полученное сообщение на форму
                            });
                        }
                        else
                        {
                            cbMailSlot.Invoke((MethodInvoker)delegate
                            {
                                cbMailSlot.Items.Add(msg);
                                if (cbMailSlot.Items.Count == 1) cbMailSlot.SelectedIndex = 0;
                            });
                        }
                    }
                
                }


            }
        }

        // присоединение к мэйлслоту
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // открываем мэйлслот, имя которого указано в поле tbMailSlot
                HandleMailSlot = DIS.Import.CreateFile(cbMailSlot.SelectedItem.ToString(), DIS.Types.EFileAccess.GenericWrite, DIS.Types.EFileShare.Read, 0, DIS.Types.ECreationDisposition.OpenExisting, 0, 0);
                if (HandleMailSlot != -1)
                {
                    send(Dns.GetHostName().ToString() + " << " + nameTb.Text);
                    btnConnect.Enabled = false;
                    btnSend.Enabled = true;
                    _connected = true;
                }
                else
                    MessageBox.Show("Не удалось подключиться к мейлслоту");
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к мейлслоту");
            }
        }



        private void send(string text)
        {
            uint BytesWritten = 0;  // количество реально записанных в мэйлслот байт
            byte[] buff = Encoding.Unicode.GetBytes(text);    // выполняем преобразование сообщения (вместе с идентификатором машины) в последовательность байт

            DIS.Import.WriteFile(HandleMailSlot, buff, Convert.ToUInt32(buff.Length), ref BytesWritten, 0);     // выполняем запись последовательности байт в мэйлслот
        }

        // отправка сообщения
        private void btnSend_Click(object sender, EventArgs e)
        {
            send(Dns.GetHostName().ToString() + " >> " + tbMessage.Text);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DIS.Import.CloseHandle(HandleMailSlot);     // закрываем дескриптор мэйлслота
            _continue = false;
            if (t != null)
                t.Abort();          // завершаем поток
            if (HandleClientMailSlot != -1)
                DIS.Import.CloseHandle(HandleClientMailSlot);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bLoadMailSlots_Click(object sender, EventArgs e)
        {
            cbMailSlot.Items.Clear();
            int BroadMailHandle = DIS.Import.CreateFile("\\\\*\\mailslot\\ServerMailslot", DIS.Types.EFileAccess.GenericWrite, DIS.Types.EFileShare.Read, 0, DIS.Types.ECreationDisposition.OpenExisting, 0, 0);
            if (BroadMailHandle != -1)
            {
                uint BytesWritten = 0;  // количество реально записанных в мэйлслот байт
                byte[] buff = Encoding.Unicode.GetBytes(Dns.GetHostName());    // выполняем преобразование сообщения (вместе с идентификатором машины) в последовательность байт
                DIS.Import.WriteFile(BroadMailHandle, buff, Convert.ToUInt32(buff.Length), ref BytesWritten, 0);     // выполняем запись последовательности байт в мэйлслот
                btnConnect.Enabled = true;
            }
            else
            {
                MessageBox.Show("Не удалось создать широковещательное сообщение");
            }
        }
    }
}