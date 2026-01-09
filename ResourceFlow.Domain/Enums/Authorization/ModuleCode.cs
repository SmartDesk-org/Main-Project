using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Enums.Authorization
{
   
        public enum ModuleCode
    {
        USR = 1, //Users
        RLS = 2, //Roles
        CDS = 3, //company detail
        FLR = 4, //company floors
        RTY = 5, //Resource Types
        FBK = 6, //FeedBack
        EMP = 7, //employee management
        SPS = 8, //subscription plans
        RES = 9, //resources
        STY = 10,// subscription type
        CUS = 11,//cumpany subscriptions
        PAY = 12,//payment
        BIL = 13,//billing
        SHI = 14,//subscription history
        NOT = 15,//notification
        CLM = 16, //client message
        APM= 17,//AppModule
        RPM= 18,//Role Permisssion
        RBP=19,//Resource Booking Permission
        RBT=20,//Resource Booking
    }

}

