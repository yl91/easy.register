﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model.PublishService
{
    public class Node
    {
        public Node(string providerName, string url,int weight,bool isAvaiable,string ip)
        {
            this.ProviderName = providerName;
            this.Url = url;
            this.Weight = weight;
            this.IsAvailable = isAvaiable;
            this.Ip = ip;
        }
        public string Ip
        {
            get;private set;
        }
        public String ProviderName
        {
            get;
            private set;
        }
        public String Url
        {
            get;
            private set;
        }
        public Int32 Weight
        {
            get;
            private set;
        }
        public Boolean IsAvailable
        {
            get;
            private set;
        }
    }
}
