   M S B A M L   `   `   `  ????L  HJobsManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:JobsManagementApp.View.ShareJobsManagementApp.View.Share  5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5      g cLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc92a3e13d40c573}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5	      I)clr-namespace:JobsManagementApp.ViewModelJobsManagementApp.ViewModel  5
      ;    5JobsManagementApp.View.Share.JobListForSingleAssignee   5      4local*clr-namespace:JobsManagementApp.View.Share  5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      XwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf     5      hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5	      8vm)clr-namespace:JobsManagementApp.ViewModel     5
      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      -   5        $"??JobListForSingleAssigneePage??5        N? 
FontFamily$  Roboto)?5       N? Title$ JobListForSingleAssignees??5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   ?? *LoadCM+  5       6$   ?? *
MaskNameCM+   CommandParameter 5   $   ??  ?? ElementName$ 
ShadowMask??5      .??5      ? 
???????.+?5   
   ?  ? RowDefinitions 5      ?? 5      $??60 ?6    ?? 5      $	??170 ?6    ?? 5       $??* ?6    .+?5"      ?? 	 ?? Orientation$	 
Horizontal=?6   $??0??62   $??5,0,0,0q?6?   .+?5#      ?? -   5        
 ??Name$	
 lbl??5*       ? Cursor$
 Hand??5$      $??45??5%      $??0??5&      $??45??5'      $
??Left=?5(      $??Center=?5)      $??0,0,0,0q?5*      $??Center=?60   $??Center=?6T   $??	20,20,0,0q?6v   .??5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=?5,      $??45??5-      $??45??5.      ???	#FF5F6388$
??Left=?50       51        52      $ MouseLeftButtonDown??6)   . 53         64   ?? *
GoBackCM+ 54   0   ?? $" JobListForSingleAssigneePage??55      57      ?? 58      $??18(?5:      ???#232360$
??Bold"?5<      $??Bottom=?6'   $??30??6B   $??10,0,0,0q?6M   ??59      ?? *
assigneeId+5<   M   ?? 5=      $??-??5>      $??18(?5?      ???#232360$??0q?5@   *   $
??Bold"?5A      $??Bottom=?6'   $??10??6B   $??0,0,0,4q?6M   ?? 5B      $??18(?5D      ???#232360$
??Bold"?5F      $??Bottom=?6'   $	??235??6B   $??0,0,0,0q?6N   ??5C      ?? *assigneeName+5F   N   ?? 5G      $??Assignee Job List??5H      $??28(?5I      ???#232360$
??Bold"?5K      $??Center=?6'   $??	185,0,0,0q?6B   ?? 5L      -   5        $??0q?5O         MaterialDesignRaisedButton#??[  5P      $??40??5Q      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??5R      ???	#FF5051F9???	#FF5051F9$	??115??6g   $??	400,0,0,0q?6s   ??5N      ?? *OpenAddJobWindowCM+.??5S      ?? $	 
Horizontal=?6!   $??50??5T      $	??120??5U      $??Center=?5V      $??Center=?5W      .+?5X        $
 Plus=?5Y      $??30??5Z      $??30??5[      $??Center=?5\      $??0q?5]      
???????$??18(?5^   0   $??5,0,0,0q?6>   ?? 5_      $??Add Job??5`      $??16(?5a      
???????$??Center=?5c      $??Center=?68   5d      5e      5f      ? 5g      $??1??6    ? ColumnDefinitions 5h      ?? 5i      $??* ?6'   ?? 5j      $??* ?6'   ?? 5k      $??* ?6'   .+?5m      ? $??0??6   .+?5n      ??  ?? CornerRadius$ 25??5o      
???????$??
25,10,5,10q?5p   ,   ?? 5q      $
??Week??5r      $??18(?5s      ???#232360$	??Top=?5u      $
??Left=?5v      $??	50,20,0,0q?5w      $
??Bold"?5x      ?? 5y       ?? 
IsEditable$ False??5}      $??30??5~      $??	10,0,10,0q?5      ???	#FF808080$
??Left=?5?      $??Center=?5?      $??Roboto Medium)?5?      $??14(?64   $
??Bold"?5?      $	??Top=?5?      $	??200??61   $??Right=?6=   $??0,15,5,0q?6Y   
?????????5z      ?? *ListWeekRage+ ?? SelectedItem 5{      ?? *CurrentWeekRange+ ?? Mode$ TwoWay=? ?? Text 5|      ?? *CurrentWeekRange+$ OneWay=? 5?        5?      $ SelectionChanged??6-   . 5?   "      68   ?? *ListWeekRageChangeCM+5?      5?      ?? 5?      $??Pending??5?      $??17(?5?      
???????$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??	50,5,0,75q?6+   ?? 5?      $??16(?5?      ???	#FF232360$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
130,5,0,75q?6+   ??5?      ?? *WeekPending+$ TwoWay=?5?   +   ?? 5?      $
??Late??5?      $??17(?5?      
???????$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
50,15,0,30q?6+   ?? 5?      $??15(?5?      ???	#FF232360$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
130,5,0,30q?6+   ??5?      ?? *
WeekLate+$ TwoWay=?5?   +   ?? 5?      $??Complete Soon??5?      $??17(?5?      
???????$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
240,5,0,75q?6+   ?? 5?      $??15(?5?      ???	#FF232360$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
370,5,0,75q?6+   ??5?      ?? *WeekCompleteSoon+$ TwoWay=?5?   +   ?? 5?      $??Complete Late??5?      $??17(?5?      
???????$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
240,0,0,30q?6+   ?? 5?      $??15(?5?      ???	#FF232360$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
370,5,0,35q?6+   ??5?      ?? *WeekCompleteLate+$ TwoWay=?5?   +   5?      ? 5?      $??1??6   .+?5?      ?? $ 25??5?      
???????$??20,10,10,10q?5?   ,   ?? 5?      $??Month??5?      $??18(?5?      ???#232360$	??Top=?5?      $
??Left=?5?      $??	50,20,0,0q?5?      $
??Bold"?5?      ?? 5?      $ False??5?      $??30??5?      $??	10,0,10,0q?5?      ???	#FF808080$
??Left=?5?      $??Center=?5?      $??Roboto Medium)?5?      $??15(?64   $
??Bold"?5?      $	??Top=?5?      $??60??61   $??Right=?6<   $??0,15,9,0q?6X   
?????????5?      ?? *	ListMonth+ 5?      ?? *CurrentMonth+$ TwoWay=? 5?      ?? *CurrentMonth+$ TwoWay=? 5?        5?      $ SelectionChanged??6-   . 5?   "      68   ?? *ListMonthChangeCM+5?      5?      ?? 5?      $??Pending??5?      $??17(?5?      
???????$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??	50,0,0,75q?6+   ?? 5?      $??16(?5?      ???	#FF232360$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
130,0,0,75q?6+   ??5?      ?? *MonthPending+$ TwoWay=?5?   +   ?? 5?      $
??Late??5?      $??17(?5?      
???????$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??	50,0,0,30q?6+   ?? 5?      $??15(?5?      ???	#FF232360$??Bottom=?5?      $
??Left=?5?      $
??Bold"?5?      $??
130,0,0,30q?6+   ??5?      ?? *	MonthLate+$ TwoWay=?5?   +   ?? 5      $??Complete Soon??5     $??17(?5     
???????$??Bottom=?5     $
??Left=?5     $
??Bold"?5     $??
240,0,0,75q?6+   ?? 5     $??15(?5	     ???	#FF232360$??Bottom=?5     $
??Left=?5     $
??Bold"?5     $??
370,0,0,75q?6+   ??5     ?? *MonthCompleteSoon+$ TwoWay=?5  +   ?? 5     $??Complete Late??5     $??17(?5     
???????$??Bottom=?5     $
??Left=?5     $
??Bold"?5     $??
240,0,0,30q?6+   ?? 5     $??15(?5     ???	#FF232360$??Bottom=?5     $
??Left=?5     $
??Bold"?5     $??
370,0,0,35q?6+   ??5     ?? *MonthCompleteLate+$ TwoWay=?5  +   5     ? 5     $??2??6   .+?5     ?? $ 25??5      
???????$??15,10,25,10q?5!  ,   ?? 5"     $
??Year??5#     $??18(?5$     ???#232360$	??Top=?5&     $
??Left=?5'     $??	45,20,0,0q?5(     $
??Bold"?5)     ?? 5*     $ False??5.     $??30??5/     $??	10,0,10,0q?50     ???	#FF808080$
??Left=?52     $??Center=?53     $??Roboto Medium)?54     $??15(?64   $
??Bold"?55     $	??Top=?56     $??80??61   $??Right=?6<   $??	0,15,25,0q?6X   
?????????5+     ?? *
ListYear+ 5,     ?? *CurrentYear+$ TwoWay=? 5-     ?? *CurrentYear+$ TwoWay=? 57       58     $ SelectionChanged??6-   . 59  "      68   ?? *ListYearChangeCM+5:     5<     ?? 5=     $??Pending??5>     $??17(?5?     
???????$??Bottom=?5A     $
??Left=?5B     $
??Bold"?5C     $??	50,0,0,75q?6+   ?? 5D     $??16(?5F     ???	#FF232360$??Bottom=?5H     $
??Left=?5I     $
??Bold"?5J     $??
130,0,0,75q?6+   ??5E     ?? *YearPending+$ TwoWay=?5J  +   ?? 5K     $
??Late??5L     $??17(?5M     
???????$??Bottom=?5O     $
??Left=?5P     $
??Bold"?5Q     $??	50,0,0,30q?6+   ?? 5R     $??15(?5T     ???	#FF232360$??Bottom=?5V     $
??Left=?5W     $
??Bold"?5X     $??
130,0,0,30q?6+   ??5S     ?? *
YearLate+$ TwoWay=?5X  +   ?? 5Y     $??Complete Soon??5Z     $??17(?5[     
???????$??Bottom=?5]     $
??Left=?5^     $
??Bold"?5_     $??
240,0,0,75q?6+   ?? 5`     $??15(?5b     ???	#FF232360$??Bottom=?5d     $
??Left=?5e     $
??Bold"?5f     $??
370,0,0,75q?6+   ??5a     ?? *YearCompleteSoon+$ TwoWay=?5f  +   ?? 5g     $??Complete Late??5h     $??17(?5i     
???????$??Bottom=?5k     $
??Left=?5l     $
??Bold"?5m     $??
240,0,0,30q?6+   ?? 5n     $??15(?5p     ???	#FF232360$??Bottom=?5r     $
??Left=?5s     $
??Bold"?5t     $??
370,0,0,35q?6+   ??5o     ?? *YearCompleteLate+$ TwoWay=?5t  +   5v     5w     ? 5x     $??2??6   .+?5y     ?? $ 20??5z     
??????? ?? Padding$ 0q?5|     $
??1250??6!   $??	0,10,0,10q?6.   ._?5}     ?  5~     ?? 5     $??50 ?6,   ?? 5?     $??* ?6,   .+?5?     ?? $	 
Horizontal=?6%   $??0??6>   .+?5?     ?? 
???????$ 10??68   $??2q?6J   $??35??6^   $	??170??6j   $??10,0,0,0q?6v   ._?5?  "   ?? -   5         ??Name$ job_type_cbx??5?  %   $	??170??5?  %   $??35??5?  %   $??5,0,5,0q?5?  %   $??0q?5?  %   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Choose Job Type??5?  %   $??15(?5?  %   $
??Bold"?63   $??Center=?5?  %   
??????? 5?  %   ?? *SelectedType+ ?? SelectedIndex 5?  %   ?? *SelectedIndexnhe+.@?5?  &   ?? $
 Hand??5?  )   
???? ??$??ALL JOBS??5?  )   ?? 5?  &   $
 Hand??5?  )   
????? ?$??WAITING??5?  )   ?? 5?  &   $
 Hand??5?  )   
??? ???$??PENDING??5?  )   ?? 5?  &   $
 Hand??5?  )   
???  ??$
??LATE??5?  )   ?? 5?  &   $
 Hand??5?  )   
??? ? ?$??COMPLETE SOON??5?  )   ?? 5?  &   $
 Hand??5?  )   
??? ???$??COMPLETE LATE??5?  )   5?  #   5?     ? 5?     $??40??5?  !   $	??130??5?  !   .+?5?  "   ?? -   5        $??0q?5?  %   3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   Value$ -1Q?5?  %      IsIndicatorVisible$
 True??5?  %      IsIndeterminate$
 True??5?  %   $??35??5?  %   $ 10??5?  %   $??Reset Filters??5?  %   ???	#FF23DF00
???????$	??110??5?  O   
?????????5?  %   ?? *	LoadCM2+5?  [   5?     ? 5?     $??40??5?  !   $	??130??5?  !   $??	400,0,0,0q?6-   .+?5?  "   ?? -   5         ??Name$ 
filter_btn??5?  %   $??0q?5?  %   #??[  5?  %   $??35??5?  %   $ 10??5?  %   
?????? 
???????$	??110??5?  Q   ??5?  %   ?? *LoadFilterCbxCM+.??5?  &   ? $??50??5?  )   $	??150??5?  )   $??Center=?5?  )   $??Center=?5?  )   .+?5?  *     $ FilterMultipleOutline=?5?  -   $??20??5?  -   $??20??5?  -   $??Stretch=?5?  -   $??30,0,0,0q?5?  -   $??0q?5?  -   ???	#FF69717D$??18(?5?  D   ?? 5?  *   $??Filter??5?  -   $??14(?5?  -   ???	#FF69717D$??Center=?5?  -   $??22,2,0,0q?6H   $??Center=?6Z   $??Roboto)?6w   $??Normal"?6?   5?  '   5?  #   ? 5?  "   -   5         ?Name$ 	popupnhe2??5?  %    ? AllowsTransparency$
 True??5?  %   $??False??5?  %   $
??Fade=?5?  %   $??Center=?5?  %    ? PlacementTarget 5?  %   ?? $" JobListForSingleAssigneePage??.??5?  &   ?? $ 20??5?  )   
???????$ 0q?5?  )   ._?5?  *   ?? .+?5?  .   ?? $??Filter??5?  1   $??18(?5?  1   ???#232360$??SemiBold"?5?  1   $
??Left=?5?  1   $??0q?5?  1   $??	20,20,0,0q?6=   ?? 5?  .   -   5        $ category_cbx??5?  1    ?? DisplayMemberPath$
 name??5?  1   $	??230??5?  1   $??30??5?  1   $??	10,0,10,0q?5?  1   ???	#FF808080$??1q?5?  1    " MaterialDesignOutlinedComboBox#??[ 5?  1   $ Category??5?  1   $	??Top=?5?  1   $??Center=?5?  1   $
??Left=?5?  1   $??Center=?5?  1   $??Roboto Medium)?5?  1   $??13(?6L   $??
30,20,30,0q?6Z   ??5?  1   ?? *CategorySource+5?  Z   ?? 5?  .   -	   5        $ dependency_cbx??5?  1   $	??230??5   1   $??30??5  1   $??	10,0,10,0q?5  1   ???	#FF808080$??1q?5  1   #??[ 5  1   $ 
Dependency??5  1   $	??Top=?5  1   $??Center=?5  1   $
??Left=?5	  1   $??Center=?5
  1   $??Roboto Medium)?5  1   $??13(?6L   $??
30,20,30,0q?6Z   ??5?  1   ?? *DependencySource+5  Z   ?? 5  .   -
   5        $ assignor_cbx??5  1   $	??230??5  1   $??30??5  1   $??	10,0,10,0q?5  1   ???	#FF808080$??1q?5  1   #??[ 5  1   $ Assignor??5  1   $	??Top=?5  1   $??Center=?5  1   $
??Left=?5  1   $??Center=?5  1   $??Roboto Medium)?5  1   $??13(?6L   $??
30,20,30,0q?6Z   ??5  1   ?? *AssignorSource+5  Z   ?? 5  .   -   5        $??0q?5  1   #??[  5  1   $??30??5   1   $ 10??5!  1   ???	#FF5051F9???	#FF5051F9$	??200??5"  `   $??0,20,0,0q?6l   .??5#  2   ? $??30??5$  5   $	??230??5%  5   $??Center=?5&  5   $??Center=?5'  5   .+?5(  6     $ Filter=?5)  9   $??20??5*  9   $??20??5+  9   $??Center=?5,  9   $??0q?5-  9   
???????$??Center=?5.  L   $??	-60,0,0,0q?5/  9   ?? 50  6   $??Filter??51  9   $??16(?52  9   
???????$??Center=?54  9   $??Center=?55  9   56  3   57  /   ?? 59  .   -   5        $
 annouce_lbl2??59  U   $y?Visible=?64   $??25??6I   $??14(?6k   
???  ??$??Center=?6?   $??Center=?6?   $??Center=?6?   $??Center=?6?   5:  +   5;  '   5=  #   5>     ? 5?     $??40??5@  !   $	??130??5A  !   .+?5B  "   ?? -   5        $ date_filter_btn??5C  %   $??0q?5E  %   #??[  5F  %   $??35??5G  %   $ 10??5H  %   
?????? 
???????$	??110??5I  Q   .??5J  &   ? $??50??5K  )   $	??150??5L  )   $??Center=?5M  )   $??Center=?5N  )   .+?5O  *     $ CalendarMinusOutline=?5P  -   $??20??5Q  -   $??20??5R  -   $??Stretch=?5S  -   $??30,0,0,0q?5T  -   $??0q?5U  -   ???	#FF69717D$??18(?5V  D   ?? 5W  *   $??Date Filter??5X  -   $??14(?5Y  -   ???	#FF69717D$??Center=?5[  -   $??22,2,0,0q?6H   $??Center=?6Z   $??Roboto)?6w   $??Normal"?6?   5\  '   5]  #   ? 5^  "   -   5        $ popupnhe??5_  %   $
 True??5`  %   $??False??5a  %   $
??Fade=?5b  %   $??Center=?5c  %    5d  %   ?? $" JobListForSingleAssigneePage??.??5f  &   ? .+?5h  *   ?? $ 20??5i  -   
???????$ 0q?5k  -   ._?5l  .   ?? .+?5m  2   ?? $??Filter By Date??5n  5   $??18(?5o  5   ???#232360$??SemiBold"?5q  5   $
??Left=?5r  5   $??0q?5s  5   $??	20,20,0,0q?6A   ?? 5t  2   $ 10??6:   $??0q?6L   $??35??6`   $	??130??6l   $??17,7,0,0q?6x   $
??Left=?6?   ._?5u  6   ?? -   5        $ date_type_cbx??5v  9   $	??130??5w  9   $??35??5x  9   $??5,10,5,0q?5y  9   $??0q?5z  9   $ Choose Field??5{  9   $??Center=?5|  9   $??14(?5}  9   $
??Bold"?6G   .@?5  :   ?? $
 Hand??5?  =   $??
Start Date??5?  =   ?? 5?  :   $
 Hand??5?  =   $??Due Date??5?  =   ?? 5?  :   $
 Hand??5?  =   $??End Date??5?  =   5?  7   5?  3   ?? 5?  2   $	??260??6<   $??Center=?6H   $??Center=?6e   $??5,20,0,2q?6?   ? 5?  2   -   5          ?Name$  panel??5?  s   ! ? Orientation$! 
Horizontal=?6<   $	??300??6U   $??2,10,0,0q?6a   .+?5?  6   	? $??	This Week??6B   $??	20,20,0,0q?6V   $	??100??6i   $??14(?6u   	? 5?  6   $??
This Month??6B   $??	60,20,0,0q?6W   $	??100??6j   $??14(?6v   	? 5?  6   $??	This Year??6B   $??	20,20,0,0q?6V   $	??100??6i   $??14(?6u   	? 5?  6   -   5        $??
Date Range??5?  ?   $??	60,20,0,0q?6?   $	??100??6?   $??14(?6?   ?? 5?  6   $	??260??6@   $??Center=?6L   $??Center=?6i   $??	16,20,0,2q?6?   5?  3   ?? 5?  2   -   5        " ??Name$" tab_control??5?  =   $	??260??6R   $y?	Collapsed=?6^   $
??Left=?6u   $	??374??6?   $??	20,20,0,0q?6?   # ? 	Resources# 5?  6   $ ?? 
TargetType% ?? Property& ?? Value' ?? 
TargetType( ??Name) ??Name* ?? Triggers+ P? Property, P? Value- ?? 
TargetName??%Y  '??       ?? 5?  :   "$ ??6@   .?5?  >   ?? % ?@?Cursor$
& Hand??6W   ?? 5?  >   % ? ??$& 14(?6Y   ?? 5?  >   % ? ??$& 25??6W   ?? 5?  >   % ? ??$& DemiBold"?6[   ?? 5?  >   % ? ??& 5?  B   ?? 5?  F   "' ??6V   .R?5?  J   ?? $( Border??5?  M   
?????? $??1q?5?  M   $ 5??5?  M   $??25??5?  M   ._?5?  N   ?? $) ContentSite??5?  Q   $
??10,2q?5?  Q   $??Center=?5?  Q   $??Center=?5?  Q   $??Header??5?  Q   5?  K   * 5?  J   P? 5?  N   + ?@??
IsSelected$
, True??6l   . ?5?  R   ?? % ? ??
& ?????6o   ?? 5?  R   $- Border??6Y   % ? ??& ?#1EA7FF6?   5?  O   P? 5?  N   + ?@??
IsSelected$, False??6l   . ?5?  R   ?? % ? ??& ?	#FF2323606o   ?? 5?  R   $- Border??6Y   % ? ??
& ?????6?   5?  O   5?  G   5?  ?   5?  ;   5?  7   .@?5?  6   ?? $
??From??6>   .??5?  :   ? # 5?  >     SecondaryCalendarDayButton:	  4System.Windows.Controls.Primitives.CalendarDayButton # MaterialDesignCalendarDayButton. ?? BasedOn-
  'MaterialDesignThemes.Wpf.CalendarAssist  SecondaryHueMidBrush " SecondaryHueMidForegroundBrush  SecondaryCalendarButton7  1System.Windows.Controls.Primitives.CalendarButton   MaterialDesignCalendarButton??%^  &	       7  &	 ?     7  ?? 5?  B   "$ 	 5?  E   8.   .?5?  F   ?? % ?@
 SelectionColor#& ?  5?  I   ?? 5?  F    % ?@
 SelectionForegroundColor#& ?  5?  I   5?  C   ?? 5?  B   "$  5?  E   8.   .?5?  F   ?? % ?@
 SelectionColor#& ?  5?  I   ?? 5?  F    % ?@
 SelectionForegroundColor#& ?  5?  I   5?  C   5?  ?   .+?5?  >   &   System.Windows.Controls.Calendar  -   5        /  Name$/ 	startDate??5?  A     PrimaryHueLightBrush#???  5?  A    "	 PrimaryHueLightForegroundBrush#??? 	 5?  A    
 PrimaryHueDarkBrush0 
  HeaderBackground#0 ? 
 5?  A    ! PrimaryHueDarkForegroundBrush1 
  HeaderForeground#1 ?  5?  A   2   CalendarDayButtonStyle#2 [ 5?  A   3   CalendarButtonStyle#3 [ 5?  A   5?  ;   5?  7   ?? 5?  6   $??To??6>   .??5?  :   ? # 5?  >   ??%^  &	       7  &	 ?     7  ?? 5?  B   "$ 	 5?  E   8.   .?5?  F   ?? % ?@
 SelectionColor#& ?  5?  I   ?? 5?  F    % ?@
 SelectionForegroundColor#& ?  5?  I   5?  C   ?? 5?  B   "$  5?  E   8.   .?5?  F   ?? % ?@
 SelectionColor#& ?  5?  I   ?? 5?  F    % ?@
 SelectionForegroundColor#& ?  5?  I   5?  C   5?  ?   .+?5?  >     -   5        $/ endDate??5?  A   #???  5?  A   #??? 	 5?  A   #0 ? 
 5?  A   #1 ?  5?  A   #2 [ 5?  A   #3 [ 5?  A   5   ;   5  7   5  3   ?? 5  2   -   5        4 ?? 	ClickMode$4 Press=?5  5   $??0q?5  5   #??[  5  5   $??30??5  5   $ 10??5	  5   ???	#FF5051F9???	#FF5051F9$	??200??5
  d   $??0,20,0,0q?6p   .??5  6   ? $??30??5  9   $	??200??5  9   $??Center=?5  9   $??Center=?5  9   .+?5  :     $ Filter=?5  =   $??20??5  =   $??20??5  =   $??Center=?5  =   $??0q?5  =   
???????$??Center=?5  P   $??	-60,0,0,0q?5  =   ?? 5  :   $??Filter??5  =   $??16(?5  =   
???????$??Center=?5  =   $??Center=?5  =   5  7   5  3   ?? 5   2   -   5        $
 annouce_lbl??5   D   $??30??68   $??14(?6Z   
???  ??$??Center=?6y   $??Center=?6?   $??Center=?6?   $??Center=?6?   5!  /   5"  +   5#  '   5$  #   5%     ?? 5&     $ 10??5'  !   
???????$??2q?5)  !   $??35??5*  !   $	??250??6-   
???????$??10,0,0,0q?6L   ._?5+  "   ? $??Center=?6'   $??Center=?6B   $	??250??6_   .+?5,  &   ??   MaterialDesignToolButton#???  5-  )   $
??Left=?5.  )   $??Center=?5/  )   $??8,0,0,0q?50  )   $??0q?6:   $??13(?6F   .??51  *     $ Magnify=?52  -   $??25??53  -   $??25??54  -   $??Center=?68   $
??Left=?6S   $??0,2,0,0q?6n   55  '   ?? 57  &   -   5        5 ??Name$5 	SearchBox??58  )   $	??200??5:  )   $ Enter job name.??5;  )   .  (MaterialDesignThemes.Wpf.TextFieldAssist6   DecorationVisibility$6 Hidden=?5<  )   $??0q?5=  )   $??15(?5>  )   $??30,0,0,0q?5?  )   $??Center=?6;   ???	#E50000006V   5@  #   5A     5B     ? 5C     $??1??6   .+?5D     ?? $
??1250??6(   $
??Left=?65   $	??Top=?6P   $??0,0,0,2q?6h   ?? 5E     $
??1250??6)   $	??430??66   .+?5F  "   ?? -   5        7 ??Name$7 	_ListView??5I  %   $	??430??5J  %   $
??1250??62   ??5G  %   ?? *Jobs+ 5H  %   ?? *SelectedItem+??5L  &   ?? 5M  *   "$ ??60     MaterialDesignGridViewItem#. [ 5N  -   8 ?? View8 5Q  &   ?? 5R  *   !9 ?? ColumnHeaderContainerStyle9 5S  .   ?? 5T  2   "$ ??68   .?5V  6   ?? % ? ??& 5W  :   ?? 5X  >   "' ??6N   .R?5Y  B   ?? $??	0,0,0,0.2q?6I   
???   ?
?????? ._?5Z  F   ?? : ??Name$: ContentHeader??6P   $??15(?5[  I   $
??Bold"?5\  I   #??z??5]  I   ; ?? Padding$; 5,5,5,5q?5^  I   #??z??6[   < ?? TextAlignment$< Center=?5_  I   5`  C   5a  ?   5c  7   ?? 5d  6   % ?@?OverridesDefaultStyle$
& True??6^   ?? 5e  6   % ? ??$& 12(?6Q   5g  3   .P?5i  .   ?? $??ID??6=   = ?? Width$= 40??6I   > ?? CellTemplate> 5j  2   ?? 5k  6   .R?5l  :   ?? $??30??6Y   $??0,10,0,0q?6d   $??SemiBold"?5m  =   $??12(?5n  =   ??5l  E   ?? *id+5n  =   5o  7   5q  /   ?? 5r  .   $??Job name??6=   $	= 160??5s  1   > 5t  2   ?? 5u  6   .R?5v  :   ?? $??SemiBold"?6[   $??12(?5w  =   $??
-10,10,0,0q?5x  =   ??5v  E   ?? *name+5x  =   5z  7   5|  /   ?? 5}  .   $??Category??6=   $= 80??5~  1   > 5  2   ?? 5?  6   .R?5?  :   ?? $??SemiBold"?6^   $??12(?5?  =   $??0,10,0,0q?5?  =   ??5?  D   ?? *
category+5?  =   5?  7   5?  /   ?? 5?  .   $??
Job Parent??6=   $	= 160??5?  1   > 5?  2   ?? 5?  6   .R?5?  :   ?? $	 Vertical=?6E   $??Center=?6\   $	??160??6y   .+?5?  >   ?? $??SemiBold"?6g   $??12(?5?  A   $??	-20,0,0,0q?5?  A   $??Center=?5?  A   ??5?  H   ?? *dependency_id+5?  A   ?? 5?  >   $??SemiBold"?6i   $??12(?5?  A   $??
-15,10,0,0q?5?  A   $??Center=?6U   ??5?  H   ?? *dependency_name+5?  U   5?  ;   5?  7   5?  /   ?? 5?  .   $??Assignor??6=   $	= 160??5?  1   > 5?  2   ?? 5?  6   .R?5?  :   ?? $	 Vertical=?6E   .+?5?  >   ?? $	 
Horizontal=?6I   .+?5?  B   ?? $??SemiBold"?6i   $??Center=?6   $??12(?5?  E   $??10,2,0,0q?5?  E   ??5?  L   ?? *assignor_id+5?  E   ?? 5?  B   $	?? - ??6L   $??SemiBold"?6W   $??Center=?6m   $??12(?5?  E   $??0,2,0,0q?5?  E   ?? 5?  B   $??SemiBold"?6k   $??Center=?6?   $??12(?5?  E   $??0,2,0,0q?5?  E   ??5?  L   ?? *assignor_type+5?  E   5?  ?   ?? 5?  >   $??SemiBold"?6g   $??Center=?6}   $??12(?5?  A   $??10,0,0,0q?5?  A   ??5?  H   ?? *assignor_name+5?  A   5?  ;   5?  7   5?  /   ?? 5?  .   $??Assignee??6=   $	= 160??5?  1   > 5?  2   ?? 5?  6   .R?5?  :   ?? $	 Vertical=?6E   .+?5?  >   ?? $	 
Horizontal=?6I   .+?5?  B   ?? $??SemiBold"?6i   $??Center=?6   $??12(?5?  E   $??10,2,0,0q?5?  E   ??5?  L   ?? *assignee_id+5?  E   ?? 5?  B   $	?? - ??6L   $??SemiBold"?6W   $??Center=?6m   $??12(?5?  E   $??0,2,0,0q?5?  E   ?? 5?  B   $??SemiBold"?6k   $??Center=?6?   $??12(?5?  E   $??0,2,0,0q?5?  E   ??5?  L   ?? *assignee_type+5?  E   5?  ?   ?? 5?  >   $??SemiBold"?6g   $??Center=?6}   $??12(?5?  A   $??10,0,0,0q?5?  A   ??5?  H   ?? *assignee_name+5?  A   5?  ;   5?  7   5?  /   ?? 5?  .   $
??Hour??6=   $= 70??5?  1   > 5?  2   ?? 5?  6   .R?5?  :   ?? $??SemiBold"?6c   $??12(?5?  =   $??	10,10,0,0q?5?  =   ??5?  D   ?? *required_hour+5?  =   5?  7   5?  /   ?? 5?  .   $??Due Date??6=   $= 90??5?  1   > 5?  2   ?? 5?  6   .R?5?  :   ?? $??5,10,0,0q?6^   $??SemiBold"?6p   $??12(?5?  =   ??5?  D   ?? *
due_date+5?  =   5?  7   5?  /   ?? 5?  .   $??Start-Finish??6=   $= 90??5?  1   > 5?  2   ?? 5?  6   .R?5?  :   ?? $	 Vertical=?6E   .+?5?  >   ?? $??5,2,0,0q?6d   $??SemiBold"?6u   $??Center=?6?   $??12(?5?  A   ??5?  H   ?? *
start_date+5?  A   ?? 5?  >   $??5,0,0,0q?6b   $??SemiBold"?6s   $??Center=?6?   $??12(?5?  A   ??5?  H   ?? *
end_date+5?  A   5?  ;   5?  7   5?  /   ?? 5?  .   $??Stage??6=   $	= 140??5?  1   > 5?  2   ?? 5?  6   .R?5?  :   ?? $??SemiBold"?6[   $??12(?5?  =   $??	30,10,0,0q?5?  =   ??5?  D   ?? *stage+5?  =   5?  7   5?  /   ?? 5?  .   $??Action??6=   > 5?  2   ?? 5?  6   .R?5?  :   ?? $??Center=?6E   $	 
Horizontal=?5?  =   .+?5?  >   ?? 
???   ?$??1q?5?  A   $ 6??5?  A   $
 Hand??5?  A   ??5?  B   ?? 5   F   "$ ??6L   ? ?? Triggers? 5  J   P? 5  N   + ?@J?IsMouseOver$
, True??5  Q   . ?5  R   ?? % ? ??& ?#00e5ff5  U   5  O   5  G    5
  B     5  F   $ MouseLeftButtonUp??6U   . 5  J      6`   ?? *DataContext.OpenEditJobCM+$ 	_ListView?? 5  M   ?? $" JobListForSingleAssigneePage??5  G   ._?5  B     $ Magnify=?6O   $??30??5  E   $??30??5  E   $
 Hand??5  E   5  ?   ?? 5  >   $??0 0 0 0q?6E   
???   ?$??1q?5  A   $ 6??5  A   $
 Hand??5  A   ??5  B   ?? 5  F   "$ ??6L   ? 5  J   P? 5  N   + ?@J?IsMouseOver$
, True??5  Q   . ?5  R   ?? % ? ??& ?#ff62555   U   5!  O   5#  G    5%  B     5&  F   $ MouseLeftButtonUp??6U   . 5'  J      6`   ?? *DataContext.DeleteJobCM+$ 	_ListView??5(  G   ._?5*  B     $ GarbageCanEmpty=?6O   $??30??5+  E   $??30??5,  E   $
 Hand??5-  E   5.  ?   50  ;   51  7   53  /   54  +   57  #   ? 58  "    % !MaterialDesignCircularProgressBar#??[ 6.   $	??100??59  %   $	??100??5:  %   $??
0,-600,0,0q?5;  %   @ ? IsIndeterminate@ 5<  %   ?? *IsGettingSource+5=     5?     5@     5A     5D     5F     ? 5G  
   -   5        A ?Name$A 
ShadowMask??5K     $??3??5G     
???????B J? Opacity$	B 0.3Q?5I     $y?	Collapsed=?5J     5K     5L     5N     