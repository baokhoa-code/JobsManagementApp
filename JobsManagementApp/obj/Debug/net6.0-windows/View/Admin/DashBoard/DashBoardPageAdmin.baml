   M S B A M L   `   `   `  ????L  HJobsManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:JobsManagementApp.View.Admin.DashBoard&JobsManagementApp.View.Admin.DashBoard  5      g cLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc92a3e13d40c573}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5      I)clr-namespace:JobsManagementApp.ViewModelJobsManagementApp.ViewModel  5	      ?    9JobsManagementApp.View.Admin.DashBoard.DashBoardPageAdmin   5      >local4clr-namespace:JobsManagementApp.View.Admin.DashBoard  5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5      8vm)clr-namespace:JobsManagementApp.ViewModel     5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      -   5        $??DashBoardPageAd??5        N? 
FontFamily$  Roboto)?5       N? Title$ UserHomePage??5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   ?? *LoadCM+  5       6$   ?? *
MaskNameCM+   CommandParameter 5   $   ??  ?? ElementName$ 
ShadowMask??5       ? 	Resources 5         testTemplate	 ?? CornerRadius
 ?? Orientation ? Cursor'  !MaterialDesignThemes.Wpf.PackIcon   Kind ?? Path ?? TextAlignment ?? Padding ? Value??%?	  &	        ?? 5   
   .R?5      ?? $	??570??5      $??80??5      $	 20??5      
???????$??	10,10,0,0q?6:   ._?5!      ?? $
 
Horizontal=?6   .+?5"      ?? $??7,0,0,0q?6   $??35??5#      $??35??5$      
?????? $??1q?5&      $	 6??5'      $
 Hand??5(      ._?5)        $??35??5*   !   $??35??5+   !   $ Magnify=?5,   !   ???	#B21EA7FF5-   !    5.        5/      $ MouseLeftButtonUp??6-   . 50   "      68   ?? $ 	_ListView??$ DataContext.OpenEditJobCM? 51   8   ?? $ DashBoardPageAd??52      54      ?? 56      $??70??6!   $??10,0,0,0q?6,   .+?57      ?? $
??Date??58   !   $??12(?59   !   $??Medium"?5:   !   ???	#FF232360$
??Wrap=?5<   !   $??Center=?65   $??0,20,0,0q?6R   5=      ?? 5>      $??12(?5@   !   $??Medium"?5A   !   ???	#FF232360$
??Wrap=?5C   !   $??Center=?65   $??Center=?5D   !   $??0,5,0,0q?6>   ??5?   !   ?? *
start_date+5D   >   5E      ?? 5G      $??60??5I   !   $??Medium"?5J   !   $??12(?5K   !   ???	#FF232360$ Center=?5M   !   $
??Wrap=?5N   !   $??Center=?5O   !   $??Center=?6>   $??5,0,0,0q?5P   !   ??5H   !   ?? *
category+5Q      ?? 5R      $	??200??5T   !   $??Medium"?5U   !   $??12(?5V   !   ???	#FF232360$
??Wrap=?5X   !   $??Center=?66   $??10,0,0,0q?5Y   !   ??5S   !   ?? *name+5Y   !   ?? 5[      $	??110??6!   .+?5\      ?? $
 
Horizontal=?6%   $??Center=?6>   .+?5]      ?? $??12(?5_   !   $??Medium"?5`   !   ???	#FF232360$
??Wrap=?5b   !   $??Center=?65   $??0,20,0,0q?5c   !   ??5^   !   ?? *	percent+5d      ?? 5e      $??%??5f   !   $??12(?5g   !   $??Medium"?5h   !   ???	#FF232360$
??Wrap=?5j   !   $??Center=?65   $??1,0,0,0q?5k   !   $ 0q?5l   !   $??15??6-   $??Bottom=?69   5m      5n      ? 5o      $??5??5q   !   $??0,10,0,0q?5r   !    5p   !   ?? *	percent+5r   !   5s      ?? 5u      $??15,0,0,0q?6   $??30??5v      
?????? $??1q?5x      $	 6??5y      $
 Hand??5z      ._?5{        $ CloseCircleOutline=?65   $??30??5|   9   $??30??5}   9   $
 Hand??5~   9   ???	#B2FF00005   9    5?        5?      $ MouseLeftButtonUp??6-   . 5?   "      68   ?? $ 	_ListView??$ DataContext.DeleteJobCM?5?      5?      5?      5?      5?      5?      .??5?      ? 
??????? ? ColumnDefinitions 5?   
   ?? 5?      $	??700 ?6   ?? 5?      $	??600 ?6   .+?5?   
   ? $??0??6   .+?5?      ?  ? RowDefinitions 5?      ?? 5?      $??40 ?6$   ?? 5?      $	??350 ?6$   ?? 5?      $	??350 ?6$   .+?5?      ?? $
 
Horizontal=?6   $??0??66   .+?5?      ?? -   5        $??18(?5?      
?????? ???#232360$
??Bold"?5?      
?????? $
??Left=?5?   Q   $??10,0,0,0q?6l   ??6   ?? *	RefreshCM+.??5?      ?? $
 
Horizontal=?6%   .+?5?        $ Reload=?66   $??24??6D   $??24??6P   ?? 5?      $??Refresh??6$   ???#232360$??18(?6K   5?      5?      5?      ? 5?      $??1??6   .+?5?      ?  5?      ?? 5?      $	??350 ?6/   ?? 5?      $	??350 ?6/   .+?5?      ? $??0??6    5?      ?? 5?   "   $
??247* ?60   ?? 5?   "   $
??103* ?60   .+?5?      ?? $	 25??5?   %   
???????$	??320??5?   %   $	??320??5?   %   $??20,12,10,18q?62   $??2??6G   ?? 5?      $??Overall Jobs??5?   %   $??18(?5?   %   ???#232360$	??Top=?5?   %   $
??Left=?5?   %   $??	30,20,0,0q?5?   %   $
??Bold"?5?   %   /  )LiveChartsCore.SkiaSharpView.WPF.PieChart  5?      ,  &LiveChartsCore.SkiaSharpView.WPF.Chart   LegendPosition$ Bottom=?5?   %   $	??300??5?   %   $	??300??5?   %   $??30,28,20,22q?62   $??2??6G      Series 5?   %   ?? *Pies+5?   G   ?? 5?      -   5         ??Name$ pieType??5?   !    ?? SelectedIndex$ 0??5?   !    ?? 
IsEditable$ False??5?   !   $??30??5?   !   $??5,0,0,0q?5?   !   ???	#FF232360)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Choose time??5?   !   $
??Left=?5?   !   $??Center=?5?   !   $??Roboto Medium)?5?   !   $
??13.5(?6<   $
??Bold"?5?   !   $	??Top=?5?   !   $	??106??69   $??Right=?6E   $??	0,15,15,0q?6a   ???	#FF232360 ?? SelectedItem 5?   !   ?? *PieSelectedType+ 5?   "     5?   &   $ Loaded??65   . 5?   *      6@   ?? *PieSelectionChangedCM+ 5?   8   ?? $ pieType??5?   '     5?   &   $ SelectionChanged??65   . 5?   *      6@   ?? *PieSelectionChangedCM+ 5?   8   ?? $ pieType??5?   '   .@?5?   "   ?? $??	This Week??6/   ?? 5?   "   $??
This Month??6/   ?? 5?   "   $??	This Year??6/   5?      5?      ? 5?      $??1??6   .+?5?      ?? $	 25??5?   %   
???????$	??320??5?   %   $	??320??5?   %   $??
-10,-5,0,0q?62   ?? 5?      .+?5?   "   ?? -   5        $ date_field_cbx??5?   %   $	??250??5?   %   ???	#FF1EA7FF$??3q?5?   %    " MaterialDesignOutlinedComboBox#??[ 5?   %   $ 
Date Field??5?   %   $??16(?6Q   $
??Bold"?6_   $??45??6q   $??
16,10,16,0q?6}   $??0,32,0,0q?6?   .@?5?   &   ?? $??
Start Date??63   ?? 5?   &   $??End Date??63   ?? 5?   &   $??Due Date??63   5?   #   ?? 5?   "   -   5        $ category_cbx??5?   %   $	??250??5?   %   ???	#FF1EA7FF$??3q?5?   %   #??[ 5?   %   $ Job Category??5?   %   $	??Top=?6S   $??16(?6k   $
??Bold"?6y   $??0,13,0,0q?6?   $??45??6?   $??
16,10,16,0q?6?   ??5?   %   ?? *CategorySource+5?   ?   (	  "System.Windows.Controls.DatePicker	  5?   "   -   5         	 Name$ 	start_dpk??5   %   $	??250??5  %   ???	#FF1EA7FF$ 
Start Date??5  %      FloatingOffset$ 0,-23&?5  %   /
  )MaterialDesignThemes.Wpf.DatePickerAssist& 
  OutlinedBorderInactiveThickness$ 3q?5  %   $ 
  OutlinedBorderActiveThickness$ 3q?5  %    $  MaterialDesignOutlinedDatePicker#??[ 5  %   $??16(?6_   $
??Bold"?6m   $??45??6   $??	16,0,16,0q?6?   $??0,13,0,0q?6?   	  5  "   -   5        $ end_dpk??5	  %   $	??250??5
  %   ???	#FF1EA7FF$ End Date??5  %   $ 0,-23&?5  %   $ 3q?5  %   $ 3q?5  %   #??[ 5  %   $??16(?6_   $
??Bold"?6m   $??0,13,0,0q?6   $??	16,0,16,0q?6?   $??45??6?   ?? 5  "   -   5         ??Name$ annouce_lbl2??5  1   $y?	Collapsed=?5  %   $??20??5  %   $??13(?6G   
???  ??$??Center=?6f   $??Center=?6?   $??Center=?6?   $??Center=?6?   ?? 5  "   $
 
Horizontal=?6-   $??0,13,0,0q?6F   .+?5  &   ?? -	   5         ??Name$ clear_filter_btn??5  )   $	??115??5  )     MaterialDesignRaisedButton#??[ 5  )   3  -MaterialDesignThemes.Wpf.ButtonProgressAssist    Value$  -1Q?5  )   !   IsIndicatorVisible$
! True??5  )   "   IsIndeterminate$
" True??5  )   $??Clear Filter??5  )   $??16(?6@   $
??Bold"?6N   $??35??6`   ???	#FF16DA16???	#FF16DA16$
??Left=?6?   $??53,0,0,0q?6?   ?? 5  &   -
   5        $ 
filter_btn??5  )   $	??110??5!  )   #??[ 5"  )   $  -1Q?5#  )   $
! True??5$  )   $
" True??5%  )   $??Filter??5&  )   $??16(?6:   $
??Bold"?6H   $??35??6Z   ???	#FF1EA7FF???	#FF1EA7FF$??20,0,0,0q?6?   5'  #   5(     5*     5+     5,     ? 5-     $??2??6   .+?5.     ?? $	 25??5/  %   
???????$	??660??51  %   $??0,0,0,5q?61   ? 52      53     ?? 54     $??50 ?6,   ?? 55     $	??320 ?6,   .+?57     ? $??0??6   .+?58     ?? $??	Job Graph??59  %   $??18(?5:  %   ???#232360$	??Top=?5<  %   $
??Left=?5=  %   $??30,7,0,0q?5>  %   $
??Bold"?5?  %   ?? 5@     ???	#FF1EA7FF$	??Top=?5C  !   $
??Left=?5D  !   $??
150,11,0,0q?5E  !   $
??Bold"?5F  !   ??5A  !   ?? *ShowAleartRange+5F  !   ?? 5G     -   5        $ 
btn_Weekly??5L  %   
?????? 
?????? $??15(?5K  %   $??30??5N  %   $??70??5O  %   $??0q?5P  %   $??270,-10,0,0q?61   ??5H  %   ?? *LineByWeekCM+.??5Q  "   ?? -   5        $ 
weekly_lbl??5R  -   $??Weekly??5S  -   $??16(?5T  -   ???#1EA7FF$??Center=?5V  -   $??Center=?5W  -   5X     ?? 5Y     -   5        $ btn_Monthly??5_  %   
?????? 
?????? $??15(?5^  %   $??30??5`  %   $??70??5a  %   $??0q?5b  %   $??420,-10,0,0q?61   ??5Z  %   ?? *LineByMonthCM+.??5c  "   ?? -   5        $ monthly_lbl??5d  .   $??Monthly??5e  -   $??16(?5f  -   ???#232360$??Center=?5h  -   $??Center=?5i  -   5j     ?? 5k     -   5        $ 
btn_Yearly??5q  %   
?????? 
?????? $??15(?5p  %   $??30??5r  %   $??70??5s  %   $??0q?5t  %   $??570,-10,0,0q?61   ??5l  %   ?? *LineByYearCM+.??5u  "   ?? -   5        $ 
yearly_lbl??5v  .   $??Yearly??5w  -   $??16(?5x  -   ???#232360$??Center=?5z  -   $??Center=?5{  -   5|     5}     ? 5~     $??1??6   .+?5     5  /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  $??28,-10,28,28q?5?  >   #   Series# 6%   ?? *Lines+6>   5?     5?     5?     5?     5?     ? 5?  
   $??1??6   .+?5?     ?  5?     ?? 5?     $??60 ?6$   ?? 5?     $??* ?6$   .+?5?     ? $??0??6   .+?5?     ?? $??My Jobs??5?     $??26(?5?     ???#232360$??Center=?5?     $
??Left=?5?     $
??Bold"?5?     ?? 5?     -   5        $??36??5?     $??36??5?     
?????? $??	106,0,0,0q?5?     $??0q?6,   $
??Left=?68   
?????? ??5?     ?? *OpenAddJobWindowCM+.??5?       $ PlusBoxOutline=?5?     $??36??5?     $??36??5?     $??Center=?5?     ???	#FF232360
?????? 
?????? $??0,0,0,5q?6?   5?     5?     ? 5?     $??1??6   .+?5?     ?? -   5        $??tabct??5?  !    5?     $ ?? 
TargetType% ?? Property& ?? Value' ?? 
TargetType( ??Name) ?? Triggers* P? Property+ P? Value, ?? 
TargetName??%  '??       ?? 5?     "$ ??6$   .?5?  "   ?? % ? ??$& 18(?6=   ?? 5?  "   % ? ??$& 40??6;   ?? 5?  "   % ? ??$
& Bold"?6?   ?? 5?  "   % ? ??& 5?  &   ?? 5?  *   "' ??6:   .R?5?  .   ?? $??Border??5?  1   
?????? $??1q?5?  1   $	 5??5?  1   ._?5?  2   ?? $( ContentSite??5?  5   $
??10,2q?5?  5   $??Center=?5?  5   $??Center=?5?  5   $??Header??5?  5   5?  /   ) 5?  .   P? 5?  2   * ?@??
IsSelected$
+ True??6P   . ?5?  6   ?? % ? ??
& ?????6S   ?? 5?  6   $, Border??6=   % ? ??& ?#1EA7FF6g   5?  3   P? 5?  2   * ?@??
IsSelected$+ False??6P   . ?5?  6   ?? % ? ??& ?	#FF2323606S   ?? 5?  6   $, Border??6=   % ? ??
& ?????6g   5?  3   5?  +   5?  #   5?     5?     .@?5?     ?? $	??All??6"   .??5?     ?? -   5        - ??Name$- 	_ListView??5?  &   #??[  5?  &   
?????? 
??????  5?  &   ?? *SelectedItem+??5?  &   ?? *Jobs+??5?  "   ?? 5?  &   "$ ??6,   .?5?  *   ?? % ? ??
& ???? 6G   ?? 5?  *   % ? ??& 6W   ?? *HorizontalContentAlignment+. ?? RelativeSource. ?? / ?? AncestorType"/ ???? 5?  *   % ? ??& 6U   ?? *VerticalContentAlignment+. ?? "/ ???? 5?  *   % ? ??$& 2,0,0,0q?6D   ?? 5?  *   % ? ??& 5?  .   ?? 5?  2   "' ??6B   .R?5?  6   ?? 0 ??Name$0 Bd??6=   #??z??6I   #??z??6u   #??z??6?   1 ?? Padding#1 z??6?   2 J? SnapsToDevicePixels$
2 true??6?   ._?5?  :   ?? #??z??6K   #2 z2 6?   #??z??6?   5?  7   ) 5?  6   P? 5?  :   * ?@J?IsMouseOver$
+ True??6Y   . ?5?  >   ?? % ? ??
& ???? 6[   5?  ;   5?  3   5?  +   5?  '   5?     5?     ?? 5?     $??Today??6"   .??5?     ?? #??[  6L    6&   ?? *SelectedItem+??5?     ?? *Jobs+??5?  "   ?? 5?  &   "$ ??6,   .?5?  *   ?? % ? ??
& ???? 6G   ?? 5?  *   % ? ??& 6W   ?? *HorizontalContentAlignment+. ?? "/ ???? 5?  *   % ? ??& 6U   ?? *VerticalContentAlignment+. ?? "/ ???? 5?  *   % ? ??$& 2,0,0,0q?6D   ?? 5?  *   % ? ??& 5?  .   ?? 5?  2   "' ??6B   .R?5?  6   ?? $0 Bd??6=   #??z??6I   #??z??6u   #??z??6?   #1 z??6?   $
2 true??6?   ._?5?  :   ?? #??z??6K   #2 z2 6?   #??z??6?   5?  7   ) 5?  6   P? 5?  :   * ?@J?IsMouseOver$
+ True??6Y   . ?5?  >   ?? % ? ??
& ???? 6[   5?  ;   5  3   5  +   5  '   5     5     ?? 5     $??Waiting??6"   .??5	     ?? #??[  6M    6'   ?? *SelectedItem+??5
     ?? *Jobs+??5  "   ?? 5  &   "$ ??6,   .?5  *   ?? % ? ??
& ???? 6G   ?? 5  *   % ? ??& 6W   ?? *HorizontalContentAlignment+. ?? "/ ???? 5  *   % ? ??& 6U   ?? *VerticalContentAlignment+. ?? "/ ???? 5  *   % ? ??$& 2,0,0,0q?6D   ?? 5  *   % ? ??& 5  .   ?? 5  2   "' ??6B   .R?5  6   ?? $0 Bd??6=   #??z??6I   #??z??6u   #??z??6?   #1 z??6?   $
2 true??6?   ._?5  :   ?? #??z??6K   #2 z2 6?   #??z??6?   5  7   ) 5  6   P? 5  :   * ?@J?IsMouseOver$
+ True??6Y   . ?5  >   ?? % ? ??
& ???? 6[   5  ;   5  3   5  +   5  '   5!     5"     ?? 5#     $??Pending??6#   .??5$     ?? #??[  6L    6&   ?? *SelectedItem+??5%     ?? *Jobs+??5&  "   ?? 5'  &   "$ ??6,   .?5(  *   ?? % ? ??
& ???? 6G   ?? 5)  *   % ? ??& 6W   ?? *HorizontalContentAlignment+. ?? "/ ???? 5*  *   % ? ??& 6U   ?? *VerticalContentAlignment+. ?? "/ ???? 5+  *   % ? ??$& 2,0,0,0q?6D   ?? 5,  *   % ? ??& 5-  .   ?? 5.  2   "' ??6B   .R?5/  6   ?? $0 Bd??6=   #??z??6I   #??z??6u   #??z??6?   #1 z??6?   $
2 true??6?   ._?50  :   ?? #??z??6K   #2 z2 6?   #??z??6?   51  7   ) 52  6   P? 53  :   * ?@J?IsMouseOver$
+ True??6Y   . ?54  >   ?? % ? ??
& ???? 6[   55  ;   57  3   59  +   5:  '   5<     5=     ?? 5>     $
??Late??6"   .??5?     ?? #??[  6L    6&   ?? *SelectedItem+??5@     ?? *Jobs+??5A  "   ?? 5B  &   "$ ??6,   .?5C  *   ?? % ? ??
& ???? 6G   ?? 5D  *   % ? ??& 6W   ?? *HorizontalContentAlignment+. ?? "/ ???? 5E  *   % ? ??& 6U   ?? *VerticalContentAlignment+. ?? "/ ???? 5F  *   % ? ??$& 2,0,0,0q?6D   ?? 5G  *   % ? ??& 5H  .   ?? 5I  2   "' ??6B   .R?5J  6   ?? $0 Bd??6=   #??z??6I   #??z??6u   #??z??6?   #1 z??6?   $
2 true??6?   ._?5K  :   ?? #??z??6K   #2 z2 6?   #??z??6?   5L  7   ) 5M  6   P? 5N  :   * ?@J?IsMouseOver$
+ True??6Y   . ?5O  >   ?? % ? ??
& ???? 6[   5P  ;   5R  3   5T  +   5U  '   5W     5X     5Y     5[     5\     5]     ? 5^  
   -   5        3 ?Name$3 
ShadowMask??5b     $??2??5^     
???????4 J? Opacity$	4 0.3Q?5`     $y?	Collapsed=?5a     5b     5c     5d     