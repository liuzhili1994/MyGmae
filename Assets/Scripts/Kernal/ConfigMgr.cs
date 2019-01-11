using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System;

namespace Kernel
{
    public class ConfigMgr : IconfigMgr
    {
        
        private static Dictionary<string, string> appSettingDic;

        public ConfigMgr(string path) {
            appSettingDic = new Dictionary<string, string>();

            InitXMLByXmlDocument(path);
            //InitXMLByXDocument(path);  
        }

        private void InitXMLByXmlDocument(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("地址错了。。。");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlNodeList nodeList = xmlDoc.FirstChild.ChildNodes;
            Debug.Log(nodeList.Count);

            for (int i = 0; i < nodeList.Count; i++)
            {
                Debug.Log(nodeList.Item(i).Name);
                Debug.Log(nodeList.Item(i).InnerText);
            }

            XmlNode firstNode = xmlDoc.FirstChild;
            Debug.Log("XML_rootNode Attribute " + firstNode.Attributes[0].Name + " = " + firstNode.Attributes[0].Value);


            
            

        }

        private void InitXMLByXDocument(string path) {
            if (!File.Exists(path))
            {
                Debug.LogError("地址错了。。。");
                return;
            }
            XDocument doc = XDocument.Load(path);
            using (XmlReader xmlReader = XmlReader.Create(new StringReader(doc.ToString())))//xml文件读写器
            {
                while (xmlReader.Read())//逐个读取  为false则为读完了 
                {
                    
                    //Debug.Log("hahaha / " +xmlReader.NodeType +" / " + xmlReader.Name + " / " + xmlReader.LocalName);
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        if(xmlReader.Name != doc.Root.Name)  //这样解决
                        Debug.Log(xmlReader.Name);  //会获取根节点的名称   怎样能不把根节点的名字读出来呢？
                    }
                    else if(xmlReader.NodeType == XmlNodeType.Text)
                    {
                        Debug.Log(xmlReader.Value);
                    }


                }
            }
            
            
            

        }

        public  Dictionary<string, string> GetAppSetting
        {
            get
            {
                return appSettingDic;
            }
        }



        public int GetAppSettingMaxNum() {
            if (appSettingDic != null && appSettingDic.Count >= 1)
            {
                return appSettingDic.Count;
            }
            else
            {
                return 0;
            }
        }
        
    }
}

