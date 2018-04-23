Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxScheduler.Localization
Imports DevExpress.Utils.Localization.Internal
Imports DevExpress.XtraScheduler.Localization

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim myLocalizer As New MyLocalizer()
		Dim provider As New DefaultActiveLocalizerProvider(Of ASPxSchedulerStringId)(myLocalizer)
		ASPxSchedulerLocalizer.SetActiveLocalizerProvider(provider)
		ASPxSchedulerLocalizer.Active = myLocalizer

		Dim myLocalizerCore As New MyLocalizerCore()
		Dim providerCore As New DefaultActiveLocalizerProvider(Of SchedulerStringId)(myLocalizerCore)
		SchedulerLocalizer.SetActiveLocalizerProvider(providerCore)
		SchedulerLocalizer.Active = myLocalizerCore
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Public Class MyLocalizer
		Inherits DevExpress.Web.ASPxScheduler.Localization.ASPxSchedulerLocalizer
		Public Overrides Function GetLocalizedString(ByVal id As ASPxSchedulerStringId) As String
			Dim ret As String = ""
			Select Case id
				Case DevExpress.Web.ASPxScheduler.Localization.ASPxSchedulerStringId.CaptionViewNavigator_Today
					Return DateTime.Now.Date.ToShortDateString()
				Case Else
					ret = MyBase.GetLocalizedString(id)
			End Select
			Return ret
		End Function
	End Class

	Public Class MyLocalizerCore
		Inherits DevExpress.XtraScheduler.Localization.SchedulerLocalizer
		Public Overrides Function GetLocalizedString(ByVal id As DevExpress.XtraScheduler.Localization.SchedulerStringId) As String
			If id = DevExpress.XtraScheduler.Localization.SchedulerStringId.MenuCmd_NewAppointment Then
				Return "New Event"
			End If

			Return MyBase.GetLocalizedString(id)
		End Function
	End Class

End Class
