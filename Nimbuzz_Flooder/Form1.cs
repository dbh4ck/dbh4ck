using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.x.muc;
using agsXMPP.Xml.Dom;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using System.IO;
using Nimbuzz_Flooder.Properties;

using MehdiComponent;
using MehdiComponent.MehdiXmpp.Create;
using MehdiComponent.Xml;







namespace Nimbuzz_Flooder
{
    public partial class Form1 : Form
    {

        public string[] a;
        private XmppClientConnection db1;
        private XmppClientConnection db2;
        private XmppClientConnection db3;
        private XmppClientConnection db4;
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();

            {
                idMaker.Created += idMaker_Created;
                idMaker.ErrorCreate += idMaker_ErrorCreate;
                idMaker.Available += idMaker_Available;
                idMaker.WrongCaptcha += idMaker_WrongCaptcha;
                idMaker.InvalidPassword += idMaker_InvalidPassword;
                idMaker.LoadChaptcha(pictureBox3);
                //idMaker.LoadChaptcha(pictureBox2);
                //idMaker.LoadChaptcha(pictureBox3);
                //idMaker.LoadChaptcha(pictureBox4);
                //idMaker.LoadChaptcha(pictureBox5);

            }
        }

        //------id maker----

        private IdMaker idMaker = new IdMaker();

        //------id maker------



        private void button1_Click(object sender, EventArgs e)
        {
           
                XmppClientConnection dbcon1 = new XmppClientConnection();
                dbcon1.Server += "nimbuzz.com";
                dbcon1.ConnectServer += "o.nimbuzz.com";
                dbcon1.Port = 5222;
                this.db1 = dbcon1;
                this.db1.Open(this.textBox1.Text, textBox3.Text, "Nimbuzz_Symbian" + (object) this.random.Next(100, 999));
                this.db1.Status += "online";
                this.db1.OnLogin += new ObjectHandler(this.login);
                this.db1.OnAuthError += new XmppElementHandler(this.failed);
                this.db1.OnClose += new ObjectHandler(this.dc);
                //dbcon1.OnReadXml += new XmlHandler(Xml1);
                this.db1.OnMessage += new MessageHandler(this.OnMessage);
                this.db1.OnPresence += new agsXMPP.protocol.client.PresenceHandler(this.OnPresence1);
                Random random = new Random();
                
                //2nd Connection

                XmppClientConnection dbcon2 = new XmppClientConnection();
                dbcon2.Server += "nimbuzz.com";
                dbcon2.ConnectServer += "o.nimbuzz.com";
                dbcon2.Port = 5222;
                this.db2 = dbcon2;
                this.db2.Open(this.textBox2.Text, textBox3.Text, "Nimbuzz_Symbian" + (object)this.random.Next(100, 999));
                this.db2.Status += "online";
                this.db2.OnLogin += new ObjectHandler(this.login2);
                this.db2.OnAuthError += new XmppElementHandler(this.failed2);
                this.db2.OnClose += new ObjectHandler(this.dc2);
                //dbcon2.OnReadXml += new XmlHandler(Xml2);
                this.db2.OnMessage += new MessageHandler(this.OnMessage2);
                this.db2.OnPresence += new agsXMPP.protocol.client.PresenceHandler(this.OnPresence2);


                //3rd Connection


                XmppClientConnection dbcon3 = new XmppClientConnection();
                dbcon3.Server += "nimbuzz.com";
                dbcon3.ConnectServer += "o.nimbuzz.com";
                dbcon3.Port = 5222;
                this.db3 = dbcon3;
                this.db3.Open(this.textBox11.Text, textBox3.Text, "Nimbuzz_Symbian" + (object)this.random.Next(100, 999));
                this.db3.Status += "online";
                this.db3.OnLogin += new ObjectHandler(this.login3);
                this.db3.OnAuthError += new XmppElementHandler(this.failed3);
                this.db3.OnClose += new ObjectHandler(this.dc3);
                //dbcon3.OnReadXml += new XmlHandler(Xml3);
                this.db3.OnMessage += new MessageHandler(this.OnMessage3);
                this.db3.OnPresence += new agsXMPP.protocol.client.PresenceHandler(this.OnPresence3);

           

               // 4th Connection

                XmppClientConnection dbcon4 = new XmppClientConnection();
                dbcon4.Server += "nimbuzz.com";
                dbcon4.ConnectServer += "o.nimbuzz.com";
                dbcon4.Port = 5222;
                this.db4 = dbcon4;
                this.db4.Open(this.textBox12.Text, textBox3.Text, "Nimbuzz_Symbian" + (object)this.random.Next(100, 999));
                this.db4.Status += "online";
                this.db4.OnLogin += new ObjectHandler(this.login4);
                this.db4.OnAuthError += new XmppElementHandler(this.failed4);
                this.db4.OnClose += new ObjectHandler(this.dc4);
                //dbcon4.OnReadXml += new XmlHandler(Xml4);
                this.db4.OnMessage += new MessageHandler(this.OnMessage4);
                this.db4.OnPresence += new agsXMPP.protocol.client.PresenceHandler(this.OnPresence4);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] strArray = this.richTextBox2.Text.Split('#');
            this.textBox1.Text = strArray[0];
            this.textBox2.Text = strArray[1];

            this.textBox11.Text = strArray[2];
            this.textBox12.Text = strArray[3];
            this.richTextBox2.Text = (string)null;
            for (int index = 4; index <= strArray.GetUpperBound(0); ++index)
                this.richTextBox2.Text = this.richTextBox2.Text + strArray[index] + "#";
                 
        }


        //1st CONN DETAILS

        private void login(object sender)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new ObjectHandler(this.login), sender);
            else
                this.textBox1.BackColor = Color.Green;
        }



        private void failed(object sender, Element e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate) new XmppElementHandler(this.failed), sender, (object) e);
            else
                this.textBox1.BackColor = Color.Red;
        }
       


        private void dc(object sender)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new ObjectHandler(this.dc), sender);
            else
                this.textBox1.BackColor = Color.Yellow;
        }



        private void OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new MessageHandler(this.OnMessage), sender, (object)msg);
            else if (msg.Type == MessageType.groupchat && msg.From.Resource == "admin")
                this.pictureBox1.Load(msg.Body.Replace("Enter the right answer to start chatting. ", ""));
            
        }


        
        void OnPresence1(object sender, agsXMPP.protocol.client.Presence pres)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new agsXMPP.protocol.client.PresenceHandler(OnPresence1), new object[] { sender, pres });
                return;
            }

            if (pres.From.Server.StartsWith("conference"))
            {
                if (pres.MucUser != null)
                {
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.owner)
                    {
                        listBox1.Items.Add(pres.From.Resource);
                    }

                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.admin)
                    {
                        listBox1.Items.Add(pres.From.Resource);
                    }
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.member)
                    {
                        listBox1.Items.Add(pres.From.Resource);
                    }
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.none)
                    {
                        listBox1.Items.Add(pres.From.Resource);
                    }

                    if (pres.Type == PresenceType.unavailable)
                    {
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.owner)
                        {
                            listBox1.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.admin)
                        {
                            listBox1.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.member)
                        {
                            listBox1.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.none)
                        {
                            listBox1.Items.Remove(pres.From.Resource);
                        }
                    }
                }

            }

        }


        
        // 2ND CONN DETAILS

        private void login2(object sender)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new ObjectHandler(this.login2), sender);
            else
                this.textBox2.BackColor = Color.Green;
        }


        private void failed2(object sender, Element e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new XmppElementHandler(this.failed2), sender, (object)e);
            else
                this.textBox2.BackColor = Color.Red;
        }


        private void dc2(object sender)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new ObjectHandler(this.dc2), sender);
            else
                this.textBox2.BackColor = Color.Yellow;
        }



        private void OnMessage2(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new MessageHandler(this.OnMessage2), sender, (object)msg);
            else if (msg.Type == MessageType.groupchat && msg.From.Resource == "admin")
                this.pictureBox2.Load(msg.Body.Replace("Enter the right answer to start chatting. ", ""));
            
        }




        void OnPresence2(object sender, agsXMPP.protocol.client.Presence pres)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new agsXMPP.protocol.client.PresenceHandler(OnPresence2), new object[] { sender, pres });
                return;
            }

            if (pres.From.Server.StartsWith("conference"))
            {
                if (pres.MucUser != null)
                {
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.owner)
                    {
                        listBox2.Items.Add(pres.From.Resource);
                    }

                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.admin)
                    {
                        listBox2.Items.Add(pres.From.Resource);
                    }
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.member)
                    {
                        listBox2.Items.Add(pres.From.Resource);
                    }
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.none)
                    {
                        listBox2.Items.Add(pres.From.Resource);
                    }

                    if (pres.Type == PresenceType.unavailable)
                    {
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.owner)
                        {
                            listBox2.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.admin)
                        {
                            listBox2.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.member)
                        {
                            listBox2.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.none)
                        {
                            listBox2.Items.Remove(pres.From.Resource);
                        }
                    }
                }

            }

        }



        //3rd CONN DETAILS

        private void login3(object sender)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new ObjectHandler(this.login3), sender);
            else
                this.textBox11.BackColor = Color.Green;
        }



        private void failed3(object sender, Element e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new XmppElementHandler(this.failed3), sender, (object)e);
            else
                this.textBox11.BackColor = Color.Red;
        }


        private void dc3(object sender)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new ObjectHandler(this.dc3), sender);
            else
                this.textBox11.BackColor = Color.Yellow;
        }

        private void OnMessage3(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new MessageHandler(this.OnMessage3), sender, (object)msg);
            else if (msg.Type == MessageType.groupchat && msg.From.Resource == "admin")
                this.pictureBox4.Load(msg.Body.Replace("Enter the right answer to start chatting. ", ""));

        }


        void OnPresence3(object sender, agsXMPP.protocol.client.Presence pres)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new agsXMPP.protocol.client.PresenceHandler(OnPresence3), new object[] { sender, pres });
                return;
            }

            if (pres.From.Server.StartsWith("conference"))
            {
                if (pres.MucUser != null)
                {
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.owner)
                    {
                        listBox3.Items.Add(pres.From.Resource);
                    }

                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.admin)
                    {
                        listBox3.Items.Add(pres.From.Resource);
                    }
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.member)
                    {
                        listBox3.Items.Add(pres.From.Resource);
                    }
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.none)
                    {
                        listBox3.Items.Add(pres.From.Resource);
                    }

                    if (pres.Type == PresenceType.unavailable)
                    {
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.owner)
                        {
                            listBox3.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.admin)
                        {
                            listBox3.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.member)
                        {
                            listBox3.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.none)
                        {
                            listBox3.Items.Remove(pres.From.Resource);
                        }
                    }
                }

            }

        }

        

        //4TH CONN DETAILS

        private void login4(object sender)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new ObjectHandler(this.login4), sender);
            else
                this.textBox12.BackColor = Color.Green;
        }
        

        private void failed4(object sender, Element e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new XmppElementHandler(this.failed4), sender, (object)e);
            else
                this.textBox12.BackColor = Color.Red;
        }

        private void dc4(object sender)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new ObjectHandler(this.dc4), sender);
            else
                this.textBox12.BackColor = Color.Yellow;
        }

        private void OnMessage4(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)new MessageHandler(this.OnMessage4), sender, (object)msg);
            else if (msg.Type == MessageType.groupchat && msg.From.Resource == "admin")
                this.pictureBox5.Load(msg.Body.Replace("Enter the right answer to start chatting. ", ""));

        }


        void OnPresence4(object sender, agsXMPP.protocol.client.Presence pres)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new agsXMPP.protocol.client.PresenceHandler(OnPresence4), new object[] { sender, pres });
                return;
            }

            if (pres.From.Server.StartsWith("conference"))
            {
                if (pres.MucUser != null)
                {
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.owner)
                    {
                        listBox4.Items.Add(pres.From.Resource);
                    }

                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.admin)
                    {
                        listBox4.Items.Add(pres.From.Resource);
                    }
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.member)
                    {
                        listBox4.Items.Add(pres.From.Resource);
                    }
                    if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.none)
                    {
                        listBox4.Items.Add(pres.From.Resource);
                    }

                    if (pres.Type == PresenceType.unavailable)
                    {
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.owner)
                        {
                            listBox4.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.admin)
                        {
                            listBox4.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.member)
                        {
                            listBox4.Items.Remove(pres.From.Resource);
                        }
                        if (pres.MucUser.Item.Affiliation == agsXMPP.protocol.x.muc.Affiliation.none)
                        {
                            listBox4.Items.Remove(pres.From.Resource);
                        }
                    }
                }

            }

        }

                
        private void button4_Click(object sender, EventArgs e)
        {
            this.db1.Send("<presence to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.textBox1.Text + "'></presence>");
            this.db2.Send("<presence to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.textBox2.Text + "'></presence>");
            this.db3.Send("<presence to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.textBox11.Text + "'></presence>");
            this.db4.Send("<presence to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.textBox12.Text + "'></presence>");
       }


        private void button5_Click(object sender, EventArgs e)
        {
            this.db1.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.textBox5.Text + "</body></message>'");
            this.db2.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.textBox6.Text + "</body></message>'");
            this.db3.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.textBox13.Text + "</body></message>'");
            this.db4.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.textBox14.Text + "</body></message>'");

            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox13.Clear();
            this.textBox14.Clear();

          for (int index = 1; index <= 2; ++index)
           {
                //for (int a = 0; a < this.listBox1.Items.Count; a++)
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id=''><body>" + this.richTextBox1.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox3.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox4.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox7.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox6.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                                
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox4.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() +"' type='chat' id='14745'><body>" + this.richTextBox1.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
               //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + listBox1.Items[a].ToString() + "' type='chat' id=''><body>" + this.richTextBox3.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + listBox1.Items[a].ToString() + "' type='chat' id=''><body>" + this.richTextBox4.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + listBox1.Items[a].ToString() + "' type='chat' id=''><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");

                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + listBox1.Items[a].ToString() + "' type='chat' id=''><body>" + this.richTextBox3.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + listBox1.Items[a].ToString() + "' type='chat' id=''><body>" + this.richTextBox4.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + listBox1.Items[a].ToString() + "' type='chat' id=''><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");

                // this.db1.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[i].ToString() + "' type='chat'><body>" + this.richTextBox1.Text + "</body></message>'");
                this.db1.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox1.Text + "</body></message>'");
                this.db1.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox3.Text + "</body></message>'");
                this.db1.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox4.Text + "</body></message>'");
                this.db1.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox5.Text + "</body></message>'");
                this.db1.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox6.Text + "</body></message>'");
                this.db1.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox7.Text + "</body></message>'");
          
              //{
                  //for (int a = 0; a < this.listBox1.Items.Count; a++)
                   //   this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox4.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
             // }
                      
            }
          for (int a = 0; a < this.listBox1.Items.Count; a++)
              this.db1.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");

            this.db1.Send("<presence type='unavailable' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.textBox1.Text + "'></presence>");


            for (int index = 1; index <= 2; ++index)

            //for (int b = 0; b < this.listBox1.Items.Count; b++)
            {
                this.db2.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox1.Text + "</body></message>'");
                this.db2.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox3.Text + "</body></message>'");
                this.db2.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox4.Text + "</body></message>'");
                this.db2.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox5.Text + "</body></message>'");
                this.db2.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox6.Text + "</body></message>'");
                this.db2.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox7.Text + "</body></message>'");
                //{
                   
              //  }
                //{
                   // for (int a = 0; a < this.listBox2.Items.Count; a++)
                     //   this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox6.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //}
                //}
                //{
                   // for (int a = 0; a < this.listBox1.Items.Count; a++)
                    //    this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox1.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //     }
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id=''><body>" + this.richTextBox1.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox3.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox4.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox7.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox6.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
            }

            for (int a = 0; a < this.listBox2.Items.Count; a++)
                this.db2.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox2.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox7.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");

            this.db2.Send("<presence type='unavailable' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.textBox2.Text + "'></presence>");


            for (int index = 1; index <= 2; ++index)

            //for (int b = 0; b < this.listBox1.Items.Count; b++)
            {

                this.db3.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox1.Text + "</body></message>'");
                this.db3.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox3.Text + "</body></message>'");
                this.db3.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox4.Text + "</body></message>'");
                this.db3.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox5.Text + "</body></message>'");
                this.db3.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox6.Text + "</body></message>'");
                this.db3.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox7.Text + "</body></message>'");

                                              
               //     for (int a = 0; a < this.listBox3.Items.Count; a++)
                 //       this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox3.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //
                //}
                //  for (int a = 0; a < this.listBox1.Items.Count; a++)
                   //     this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox3.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
               //
                //this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id=''><body>" + this.richTextBox1.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox3.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox4.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox7.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox6.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
            }

            for (int a = 0; a < this.listBox1.Items.Count; a++)
                this.db3.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
               

            this.db3.Send("<presence type='unavailable' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.textBox2.Text + "'></presence>");



            for (int index = 1; index <= 2; ++index)

            //for (int b = 0; b < this.listBox1.Items.Count; b++)
            {

                this.db4.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox1.Text + "</body></message>'");
                this.db4.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox3.Text + "</body></message>'");
                this.db4.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox4.Text + "</body></message>'");
                this.db4.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox5.Text + "</body></message>'");
                this.db4.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox6.Text + "</body></message>'");
                this.db4.Send("<message to='" + this.textBox4.Text + "@conference.nimbuzz.com' type='groupchat'><body>" + this.richTextBox7.Text + "</body></message>'");

                                   
                              //   for (int a = 0; a < this.listBox4.Items.Count; a++)
                 //       this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox4.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox6.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
              
                //}
                                 //   for (int a = 0; a < this.listBox1.Items.Count; a++)
                  //     this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox1.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id=''><body>" + this.richTextBox1.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox3.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox4.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox7.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox6.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
                //this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[b].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox5.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
            }

            for (int a = 0; a < this.listBox1.Items.Count; a++)
                this.db4.Send("<message xmlns='jabber:client' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.listBox1.Items[a].ToString() + "'  type='chat' id='2'><body>" + this.richTextBox7.Text + "</body><active xmlns='http://jabber.org/protocol/chatstates' /><x xmlns='jabber:x:event'><composing /></x></message>");
               
            this.db4.Send("<presence type='unavailable' to='" + this.textBox4.Text + "@conference.nimbuzz.com/" + this.textBox2.Text + "'></presence>");        

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.db1.Close();
            this.db2.Close();
            this.db3.Close();
            this.db4.Close();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                
                MessageBox.Show("Please Enter Your Account Name");
                return;
            }
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Please Enter Your Password");
                return;
            }
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Please Enter Captcha");
                return;
            }
            idMaker.Create(textBox7.Text, textBox8.Text, textBox9.Text);
            textBox9.Clear();
            //pictureBox1.Hide();
            idMaker.LoadChaptcha(pictureBox3);
        }


        private void idMaker_Created(IdMaker idMaker, string msg, string data)
        {
            MessageBox.Show("Id Created Sucessfully!", "Attention!");
            return;
        }

        private void idMaker_ErrorCreate(IdMaker idMaker)
        {
            
            MessageBox.Show("Error in Creating Id", "Attention!");
            return;
        }

        private void idMaker_Available(IdMaker idMaker, bool available)
        {
            Invoke(new Action(delegate
            {
                if (available == false)
                {
                    var msgBox = new MehdiMessageBox("\nThis Id is Already Created!", "Attention",
                    MehdiMessageBox.Type.Error);
                    //msgBox.MessageColor = Color.Red;
                    //msgBox.TitleColor = Color.Red;
                    msgBox.ShowDialog();
                }
            }));
        }


        private void idMaker_InvalidPassword(IdMaker idMaker, string msg)
        {
            MessageBox.Show("Invalid Password", "Error");
            return;
        }

        private void idMaker_WrongCaptcha(IdMaker idMaker, string msg)
        {
            MessageBox.Show("Wrong Captcha", "Error");
            return;
        }



        public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch 
            {
                
            }

            return image;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Wait...Downloading Requested Avatar!");
            System.Drawing.Image image = DownloadImageFromUrl("http://avatar.nimbuzz.com/getAvatar?jid="+textBox10.Text+"%40nimbuzz.com");
                                             
            string img = textBox10.Text+".png";
            string rootPath = @"C:\DB-WAS-HERE";

            // If directory does not exist, create it. 

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }


            string fileName = System.IO.Path.Combine(rootPath, img);
            image.Save(fileName);
            MessageBox.Show("Download Completed!");
        
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string strfilename = openFileDialog1.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    richTextBox2.Text = filetext;
                }
            }
                      
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }




    }

   
}

// ##### CODED BY DB~@NC #####
// ##### OCT., 2015 #####


