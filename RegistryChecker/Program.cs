using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using  System.Configuration;

namespace RegistryChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string registryValue = string.Empty;
            RegistryKey localKey = null;
            if (Environment.Is64BitOperatingSystem)
            {
                localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
            }

            try
            {
                localKey = localKey.OpenSubKey(ConfigurationManager.AppSettings["RegKey"]);
                registryValue = localKey.GetValue(ConfigurationManager.AppSettings["RegValue"]).ToString();
            }
            catch (NullReferenceException nre)
            {


            }

            Console.WriteLine(string.Concat(ConfigurationManager.AppSettings["RegKey"], @"\", ConfigurationManager.AppSettings["RegValue"], " - ", registryValue));
            Console.WriteLine();
            //   return registryValue;
        }
    }
}
