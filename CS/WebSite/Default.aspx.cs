using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler.Localization;
using DevExpress.Utils.Localization.Internal;
using DevExpress.XtraScheduler.Localization;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Init(object sender, EventArgs e)
    {
        MyLocalizer myLocalizer = new MyLocalizer();
        DefaultActiveLocalizerProvider<ASPxSchedulerStringId> provider = 
            new DefaultActiveLocalizerProvider<ASPxSchedulerStringId>(myLocalizer);
        ASPxSchedulerLocalizer.SetActiveLocalizerProvider(provider);
        ASPxSchedulerLocalizer.Active = myLocalizer;

        MyLocalizerCore myLocalizerCore = new MyLocalizerCore();
        DefaultActiveLocalizerProvider<SchedulerStringId> providerCore =
            new DefaultActiveLocalizerProvider<SchedulerStringId>(myLocalizerCore);
        SchedulerLocalizer.SetActiveLocalizerProvider(providerCore);
        SchedulerLocalizer.Active = myLocalizerCore;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

    public class MyLocalizer : DevExpress.Web.ASPxScheduler.Localization.ASPxSchedulerLocalizer
    {
        public override string GetLocalizedString(ASPxSchedulerStringId id)
        {
            string ret = "";
            switch (id)
            {
                case DevExpress.Web.ASPxScheduler.Localization.ASPxSchedulerStringId.CaptionViewNavigator_Today: 
                    return DateTime.Now.Date.ToShortDateString();
                default:
                    ret = base.GetLocalizedString(id);
                    break;
            }
            return ret;
        }
    }

    public class MyLocalizerCore : DevExpress.XtraScheduler.Localization.SchedulerLocalizer {
        public override string GetLocalizedString(DevExpress.XtraScheduler.Localization.SchedulerStringId id) {
            if (id == DevExpress.XtraScheduler.Localization.SchedulerStringId.MenuCmd_NewAppointment )
                return "New Event";

            return base.GetLocalizedString(id);
        }
    }

}
