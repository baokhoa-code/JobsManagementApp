   M S B A M L   `   `   `  ????L  HJobsManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:JobsManagementApp.View.Admin.Report#JobsManagementApp.View.Admin.Report  5      g cLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc92a3e13d40c573}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5      I)clr-namespace:JobsManagementApp.ViewModelJobsManagementApp.ViewModel  5	      C    =JobsManagementApp.View.Admin.Report.ReportManagementPageAdmin   5      ;local1clr-namespace:JobsManagementApp.View.Admin.Report  5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5      8vm)clr-namespace:JobsManagementApp.ViewModel     5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5
      -   5        $??ReportManagePage??5        N? 
FontFamily$  Roboto)?5       N? Title$ JobManagementAdmin??5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   ?? *
MaskNameCM+   CommandParameter 5   $   ??  ?? ElementName$ 
ShadowMask??  5       6$   ?? *LoadCM+5      .??5      ? 
???????.+?5   
   ?  ? RowDefinitions 5      ?? 5      $??60 ?6    ?? 5      $??* ?6    .+?5       ?? 	 ?? Orientation$	 
Horizontal=?6   $??0??62   $??5,0,0,0q?6?   .+?5!      ?? -   5        $??0q?5$         MaterialDesignRaisedButton#??[  5%      $??40??5&      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 10??5'      ???	#FF5051F9???	#FF5051F9$	??130??5(      $??
1140,0,0,0q?6!   ??5#      ?? *OpenAddReportWindowCM+.??5)      ?? $	 
Horizontal=?6!   $??50??5*      $	??130??5+      $??Center=?5,      $??Center=?5-      .+?5.      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=?5/      $??30??50      $??30??51      $??Center=?52      $??0q?53      
???????$??18(?54   0   $??5,0,0,0q?6>   ?? 55      $??
Add Report??56      $??16(?57      
???????$??Center=?59      $??Center=?68   5:      5;      5<      ? 5=      $??2??6   .+?5>      ??  ?? CornerRadius$ 20??5?      
??????? ?? Padding$ 0q?5A      $
??1250??6!   $??	0,10,0,30q?6.   $	??650??6A   ._?5B      ?  5C      ?? 5D      $??50 ?6,   ?? 5E      $??* ?6,   .+?5G      ?? $	 
Horizontal=?6%   $??0??6>   .+?5I      ? $??40??5J   !   $	??130??5K   !   $??10,12.5,0,0q?6-   .+?5L   "   ?? -   5        $??0q?5N   %   3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   Value$ -1Q?5O   %      IsIndicatorVisible$
 True??5P   %      IsIndeterminate$
 True??5Q   %   $??35??5R   %   $
 10??5S   %   $??Reset Filters??5T   %   ???	#FF23DF00
???????$	??110??5U   O   
???????6[   5V      ? 5X      $??40??5Y   !   $	??130??5Z   !   $??700,12.5,0,0q?6-   .+?5[   "   ?? -   5         ??Name$ date_filter_btn??5\   %   $??0q?5^   %   #??[  5_   %   $??35??5`   %   $
 10??5a   %   
?????? 
???????$	??110??5b   Q   .??5c   &   ? $??50??5d   )   $	??150??5e   )   $??Center=?5f   )   $??Center=?5g   )   .+?5h   *     $ CalendarMinusOutline=?5i   -   $??20??5j   -   $??20??5k   -   $??Stretch=?5l   -   $??30,0,0,0q?5m   -   $??0q?5n   -   ???	#FF69717D$??18(?5o   D   ?? 5p   *   $??Date Filter??5q   -   $??14(?5r   -   ???	#FF69717D$??Center=?5t   -   $??22,2,0,0q?6H   $??Center=?6Z   $??Roboto)?6w   $??Normal"?6?   5u   '   5v   #   ? 5w   "   -   5         ?Name$ popupnhe??5x   %    ? AllowsTransparency$
 True??5y   %   $??False??5z   %   $
??Fade=?5{   %   $??Center=?5|   %    ? PlacementTarget 5}   %   ?? $ ReportManagePage??.??5   &   ? .+?5?   *   ?? $ 20??5?   -   
???????$ 0q?5?   -   ._?5?   .   ?? .+?5?   2   ?? $??Filter By Date??5?   5   $??18(?5?   5   ???#232360$??SemiBold"?5?   5   $
??Left=?5?   5   $??0q?5?   5   $??	20,20,0,0q?6A   ? 5?   2   -   5         ?Name$ panel??5?   N    ? Orientation$ 
Horizontal=?5?   <   $	??300??6U   $??2,10,0,0q?5?   <   .+?5?   6   	? -   5         	?Name$ 	week_rbtn??5?   B   $??	This Week??6U   $??	20,20,0,0q?6i   $	??100??6|   $??14(?6?   	? 5?   6   -   5        $ 
month_rbtn??5?   B   $??
This Month??6V   $??	60,20,0,0q?6k   $	??100??6~   $??14(?6?   	? 5?   6   -	   5        $ 	year_rbtn??5?   B   $??	This Year??6U   $??	20,20,0,0q?6i   $	??100??6|   $??14(?6?   	? 5?   6   -
   5        $ day_range_rbtn??5?   B   $??
Date Range??6?   $??	60,20,0,0q?6?   $	??100??6?   $??14(?6?   ?? 5?   6   $	??260??6@   $??Center=?6L   $??Center=?6i   $??	16,20,0,2q?6?   5?   3   ?? 5?   2   -   5         ??Name$ tab_control??5?   =   $	??260??6R   $y?	Collapsed=?6^   $
??Left=?6u   $	??374??6?   $??	20,20,0,0q?6?    ? 	Resources 5?   6    ?? 
TargetType ?? Property ?? Value ?? 
TargetType ??Name ??Name  ?? Triggers! P? Property" P? Value# ?? 
TargetName??%Y  '??       ?? 5?   :   " ??6@   .?5?   >   ??  ?@?Cursor$
 Hand??6W   ?? 5?   >    ? ??$ 14(?6Y   ?? 5?   >    ? ??$ 25??6W   ?? 5?   >    ? ??$ DemiBold"?6[   ?? 5?   >    ? ?? 5?   B   ?? 5?   F   " ??6V   .R?5?   J   ?? $ Border??5?   M   
?????? $??1q?5?   M   $ 5??5?   M   $??25??5?   M   ._?5?   N   ?? $ ContentSite??5?   Q   $
??10,2q?5?   Q   $??Center=?5?   Q   $??Center=?5?   Q   $??Header??5?   Q   5?   K     5?   J   P? 5?   N   ! ?@??
IsSelected$
" True??6l   . ?5?   R   ??  ? ??
 ?????6o   ?? 5?   R   $# Border??6Y    ? ?? ?#1EA7FF6?   5?   O   P? 5?   N   ! ?@??
IsSelected$" False??6l   . ?5?   R   ??  ? ?? ?	#FF2323606o   ?? 5?   R   $# Border??6Y    ? ??
 ?????6?   5?   O   5?   G   5?   ?   5?   ;   5?   7   .@?5?   6   ?? $
??From??6>   .??5?   :   ??  5?   >     SecondaryCalendarDayButton:  4System.Windows.Controls.Primitives.CalendarDayButton # MaterialDesignCalendarDayButton$ ?? BasedOn-	  'MaterialDesignThemes.Wpf.CalendarAssist  SecondaryHueMidBrush " SecondaryHueMidForegroundBrush  SecondaryCalendarButton7
  1System.Windows.Controls.Primitives.CalendarButton   MaterialDesignCalendarButton??%^  &	       7  &	 ?     7  ?? 5?   B   "  5?   E   8$   .?5?   F   ??  ?@	 SelectionColor# ?  5?   I   ?? 5?   F     ?@	 SelectionForegroundColor# ?  5?   I   5?   C   ?? 5?   B   " 
 5?   E   8$   .?5?   F   ??  ?@	 SelectionColor# ?  5?   I   ?? 5?   F     ?@	 SelectionForegroundColor# ?  5?   I   5?   C   5?   ?   .+?5?   >   )  #MaterialDesignThemes.Wpf.TimePicker  -   5        %  Name$% start_picker??5?   A   &   WithSeconds$& False??5?   A   $??25(?5?   A   $??Bottom=?5?   A   $??35??5?   A   /  )MaterialDesignThemes.Wpf.ValidationAssist'   FontSize$' 0.001Q?5?   A   $|?False??5?   A   
???   ?$	??150??6f   $
??Left=?6r   &   System.Windows.Controls.Calendar  5?   >   -   5        (  Name$( 	startDate??5?   A     PrimaryHueLightBrush#???  5?   A    " PrimaryHueLightForegroundBrush#???  5?   A    	 PrimaryHueDarkBrush) 	  HeaderBackground#) ? 	 5?   A    !
 PrimaryHueDarkForegroundBrush* 	  HeaderForeground#* ? 
 5?   A   +   CalendarDayButtonStyle#+ [ 5?   A   ,   CalendarButtonStyle#, [ 5?   A   5?   ;   5?   7   ?? 5?   6   $??To??6>   .??5?   :   ??  5?   >   ??%^  &	       7  &	 ?     7  ?? 5?   B   "  5?   C   8$   .?5?   F   ??  ?@	 SelectionColor# ?  5?   I   ?? 5?   F     ?@	 SelectionForegroundColor# ?  5?   I   5?   C   ?? 5?   B   " 
 5?   E   8$   .?5?   F   ??  ?@	 SelectionColor# ?  5?   I   ?? 5?   F     ?@	 SelectionForegroundColor# ?  5   I   5  C   5  ?   .+?5  >     -   5        $% 
end_picker??5  A   $& False??5  A   $??25(?5  A   $??Bottom=?5  A   $??35??5  A   $' 0.001Q?5	  A   $|?False??5
  A   
???   ?$	??150??6f   $
??Left=?6r     5  >   -   5        $( endDate??5  A   #???  5  A   #???  5  A   #) ? 	 5  A   #* ? 
 5  A   #+ [ 5  A   #, [ 5  A   5  ;   5  7   5  3   ?? 5  2   -   5        - ?? 	ClickMode$- Press=?5  5   $??0q?5  5   #??[  5  5   $??30??5  5   $
 10??5  5   ???	#FF5051F9???	#FF5051F9$	??200??5  d   $??0,20,0,0q?6p   .??5  6   ? $??30??5  9   $	??200??5   9   $??Center=?5!  9   $??Center=?5"  9   .+?5#  :     $ Filter=?5$  =   $??20??5%  =   $??20??5&  =   $??Center=?5'  =   $??0q?5(  =   
???????$??Center=?5)  P   $??	-60,0,0,0q?5*  =   ?? 5+  :   $??Filter??5,  =   $??16(?5-  =   
???????$??Center=?5/  =   $??Center=?50  =   51  7   52  3   ?? 53  2   -   5        . ??Name$. annouce_lbl??53  D   $??30??68   $??14(?6Z   
???  ??$??Center=?6y   $??Center=?6?   $??Center=?6?   $??Center=?6?   54  /   55  +   56  '   57  #   58     ?? 59     $ 10??5:  !   
???????$??2q?5<  !   $??35??5=  !   $	??250??6-   
???????$??10,12.5,0,0q?6L   ._?5>  "   ? .+?5?  &   ??   MaterialDesignToolButton#???  5@  )   $
??Left=?5A  )   $??Center=?5B  )   $??5,0,0,0q?5C  )   $??0q?6:   $??13(?6F   .??5D  *     $ Magnify=?5E  -   $??24??5F  -   $??24??5G  -   $??Center=?68   $??Center=?6S   $??3,1,0,0q?6p   5H  '   ?? 5J  &   -   5        / ??Name$/ 	SearchBox??5K  )   $	??200??5M  )   )  #MaterialDesignThemes.Wpf.HintAssist0   Hint$"0 Enter report tile, job name.??5N  )   .  (MaterialDesignThemes.Wpf.TextFieldAssist1   DecorationVisibility$1 Hidden=?5O  )   $??0q?5P  )   $??15(?5Q  )   $??30,0,0,0q?5R  )   $??Center=?6;   ???	#E50000006V   5S  #   5T     5U     ? 5V     $??1??6   .+?5W     ?? $
??1250??6(   $
??Left=?65   $	??Top=?6P   $??	0,10,0,10q?6h   6~   ?? 5Y     $
??1250??6)   $	??580??66   $	??Top=?6C   $??0,25,0,0q?6[   .+?5Z  "   ?? -   5        2 ??Name$2 	_ListView??5]  %   $	??580??5^  %   $
??1250??62   ??5[  %   ?? *	Reports+3 ?? SelectedItem3 5\  %   ?? *SelectedItem+??5`  &   ?? 5a  *   " ??60     MaterialDesignGridViewItem#$ [ 5b  -   4 ?? View4 5e  &   ?? 5f  *   !5 ?? ColumnHeaderContainerStyle5 5g  .   ?? 5h  2   " ??68   .?5j  6   ??  ? ?? 5k  :   ?? 5l  >   " ??6N   .R?5m  B   ?? $??	0,0,0,0.2q?6I   
???   ?
?????? ._?5n  F   ?? 6 ??Name$6 ContentHeader??6P   $??15(?5o  P   $
??Bold"?5p  P   $??Center=?5q  P   #??z??5s  P   7 ?? Padding$7 5,5,5,15q?5t  P   #??z??6c   8 ?? TextAlignment$8 Center=?5u  P   5v  C   5w  ?   5y  7   ?? 5z  6    ?@?OverridesDefaultStyle$
 True??6^   ?? 5{  6    ? ??$ 12(?6Q   5}  3   .P?5  .   ?? $??ID??6=   9 ?? Width$	9 100??6I   : ?? CellTemplate: 5?  2   ?? 5?  6   .R?5?  :   ?? $??30??6Y   $??	27,10,0,0q?6d   $??SemiBold"?5?  E   $??12(?5?  E   ??5?  E   ?? *id+5?  E   5?  7   5?  /   ?? 5?  .   $
??Tile??6=   $	9 215??5?  1   : 5?  2   ?? 5?  6   .R?5?  :   ?? $??SemiBold"?6[   $??12(?5?  =   $??0,10,0,0q?5?  =   ??5?  E   ?? *tile+5?  =   5?  7   5?  /   ?? 5?  .   $??Description??6=   $	9 330??5?  1   : 5?  2   ?? 5?  6   .R?5?  :   ?? $	??330??6E   $??SemiBold"?6n   $??Center=?5?  =   $8 Center=?5?  =   $??WrapWithOverflow=?5?  =   $??12(?5?  =   $??0,10,0,0q?5?  =   ??5?  Q   ?? *description+5?  =   5?  7   5?  /   ?? 5?  .   $??Job name??6=   $	9 250??5?  1   : 5?  2   ?? 5?  6   .R?5?  :   ?? $	??250??6E   $	 Vertical=?6R   $??Center=?5?  E   .+?5?  >   ?? $??SemiBold"?5?  I   $??12(?5?  I   $??Center=?5?  I   ??5?  I   ?? *job_id+5?  I   ?? 5?  >   $??SemiBold"?5?  I   $??12(?5?  I   $??Center=?5?  I   ??5?  I   ?? *
job_name+5?  I   5?  ;   5?  7   5?  /   ?? 5?  .   $??Created Time??6=   $	9 250??5?  1   : 5?  2   ?? 5?  6   .R?5?  :   ?? $??Center=?5?  =   $8 Center=?5?  =   $??WrapWithOverflow=?5?  =   $	??250??5?  =   $??0,10,0,0q?5?  =   $??SemiBold"?6O   $??12(?5?  =   ??5?  =   ?? *created_time+5?  =   5?  7   5?  /   ?? 5?  .   $??Action??6=   : 5?  2   ?? 5?  6   .R?5?  :   ?? $??Center=?6E   $	 
Horizontal=?5?  =   .+?5?  >   ?? 
???   ?$??1q?5?  A   $ 6??5?  A   ; ? Cursor$
; Hand??5?  A   ??5?  B   ?? 5?  F   " ??6L   < ?? Triggers< 5?  J   P? 5?  N   ! ?@J?IsMouseOver$
" True??5?  Q   . ?5?  R   ??  ? ?? ?#00e5ff5?  U   5?  O   5?  G   ._?5?  B     $ Magnify=?6Z   $??30??5?  E   $??30??5?  E   $
; Hand??5?  E    5?  B     5?  F   $ MouseLeftButtonUp??6U   . 5?  J      6`   ?? $ ReportManagePage??= ?? Path$&=  DataContext.OpenEditReportPageCM? 5?  `   ?? $ ReportManagePage??5?  G   5?  ?   ?? 5?  >   $??0 0 0 0q?6E   
???   ?$??1q?5?  A   $ 6??5?  A   $
; Hand??5?  A   ??5?  B   ?? 5?  F   " ??6L   < 5?  J   P? 5?  N   ! ?@J?IsMouseOver$
" True??5?  Q   . ?5?  R   ??  ? ?? ?#ff62555?  U   5?  O   5?  G   ._?5?  B     $ GarbageCanEmpty=?6Z   $??30??5?  E   $??30??5?  E   $
; Hand??5?  E    5?  B     5?  F   $ MouseLeftButtonUp??6U   . 5?  J      6`   ?? $ 	_ListView??$ = DataContext.DeleteReportCM?5?  G   5?  ?   5?  ;   5?  7   5  /   5  +   5  #   ? 5  "    % !MaterialDesignCircularProgressBar#??[ 6.   $	??100??5  %   $	??100??5  %   $??
0,-600,0,0q?5	  %   > ? IsIndeterminate> 5
  %   ?? *IsGettingSource+5     5     5     5     5     ? 5     -   5        ? ?Name$? 
ShadowMask??5     $??2??5     
???????@ J? Opacity$	@ 0.3Q?5     $y?	Collapsed=?5     5     5     5     5     