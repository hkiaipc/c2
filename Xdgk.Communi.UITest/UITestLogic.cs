using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
using Xdgk.Communi.Builder;
using Xdgk.Communi.XmlBuilder;

namespace Xdgk.Communi.UITest
{
    class UITestLogic
    {
        public Communi.CommuniSoft Soft;

        public UITestLogic()
        {
            DeviceDefineBuilderBase d = new XmlDeviceDefineBuild( "xml\\devicedefine.xml" );
            HardwareBuilderBase h = new XmlHardwareBuilder("xml\\hardware.xml");
            TaskFactoryCollectionBuilder t = new XmlTaskFactoryCollectionBuilder("xml\\task.xml");
            ListenBuilderBase l = new XmlListenBuilder("xml\\listenport.xml");

            CommuniSoftBuilder b = new CommuniSoftBuilder(d, h, t, l);
            //Soft = b.Build();
            b.Build(CommuniSoft.Default);
            Soft = CommuniSoft.Default;
        }

        public UITestLogic( Communi.CommuniSoft soft )
        {
            this.Soft = soft;
            this.Soft.CommuniPortManager.CommuniPortReceivedEvent += 
                new CommuniPortReceivedEventHandler(CommuniPortManager_CommuniPortReceivedEvent);
            this.Soft.TaskManager.Timeout = TimeSpan.FromSeconds(1);
            this.BuildHardware();
            this.AddTestTask();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CommuniPortManager_CommuniPortReceivedEvent(object sender, CommuniPortReceivedEventArgs e)
        {
            string s = BitConverter.ToString(e.ReceivedBytes);
            Console.WriteLine( s );
        }

        /// <summary>
        /// 
        /// </summary>
        public void Listen()
        {
            SocketListener sl = new SocketListener(1234);
            sl.Start();
            Soft.SocketListenerManager.Add(sl);

            SocketListener sl2 = new SocketListener(21);
            sl2.Start();
            Soft.SocketListenerManager.Add(sl2);
        }

        public void BuildHardware()
        {
            Station st = new Station("st", new SocketCommuniType("1234"));
            st.Devices.Add(new TestDevice(0));

            this.Soft.HardwareManager.Stations.Add(st);
        }
        /// <summary>
        /// 
        /// </summary>
        public void AddTestTask()
        {
            TestDevice td = this.Soft.HardwareManager.Stations[0].Devices[0] as TestDevice;
            Task t = new Task(td, td.TestOpera, Strategy.CreateCycleStrategy( 1 ));
            this.Soft.TaskManager.Tasks.AddToTail(t);
        }
    }
}
