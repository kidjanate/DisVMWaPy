using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using System.Diagnostics;
using TestStack.White;

namespace DisVMWapy
{
    class Program
    {
        Process[] vmWare;
        DiscordRpcClient client;
        bool open;
        bool start;
        string oldTitle;
        string newTitle;
        static void Main(string[] args)
        {
            Program p = new Program();
            
            p.progess();
            
        }
        void progess()
        {
            Console.Title = "DisVMWapy";
            WriteType.Normal("DisVMWapy is started");
            Console.ForegroundColor = ConsoleColor.Red;
            client = new DiscordRpcClient("759742471642152970");
            client.Initialize();
            while (true)
            {
                StartDiscordRPC();
            }
            
        }
        void StartDiscordRPC()
        {
            vmWare = Process.GetProcessesByName("vmware");
            
            if (vmWare == null)
            {
                return;
            }
            if(vmWare.Length >= 1)
            {
                if(vmWare[0].MainWindowTitle == "" || vmWare[0].MainWindowTitle == null)
                {
                    return;
                }
                newTitle = vmWare[0].MainWindowTitle;
                if(newTitle != oldTitle)
                {
                    oldTitle = newTitle;
                    open = false;
                }
                if (open)
                {
                    
                    return;
                }

                open = false;
                

                if (!vmWare[0].MainWindowTitle.Contains('-'))
                {
                    if (vmWare[0].MainWindowTitle == "VMware Workstation")
                    {
                        WriteType.Normal("On menus");
                        RPC.ChangeRPC(client, "In main menu", "Selecting VM", "icon", "menu", "In menus", false);
                    }
                }
                else
                {
                    WriteType.Normal($"Running {vmWare[0].MainWindowTitle.Split('-')[0]}");
                    RPC.ChangeRPC(client, "In main menu", $"Running {vmWare[0].MainWindowTitle.Split('-')[0]}", "icon", "play", $"{vmWare[0].MainWindowTitle.Split('-')[0]}", true);

                }
                
                

                
                start = true;
                
                
                open = true;
            }
            if (vmWare.Length == 0)
            {
                
                if (open)
                {
                    WriteType.Error("VMware has been closed");
                    client.ClearPresence();
                }
                open = false;
            }
        }
    }
}
