   M S B A M L   `   `   `  ????L  HJobsManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:JobsManagementApp.View.GeneralJobsManagementApp.View.General  5      /    )JobsManagementApp.View.General.ForgotPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:JobsManagementApp.View.General     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      -   5          N?Name$  
forgotpage??5       N? Title$ 
ForgotPage??5         LoginVM ? DataContext# [  5       ? Triggers 5      :? 5   
    :? RoutedEvent$ Page.Loaded??6   .[?5      ?? .??5      ?? .??5      t?  ?? 
TargetName$ 
forgotpage??5       ?? TargetProperty$ Margin?5       t? From 	440,0,0,05      	 t? To 05      	 g? Duration$	 0:0:0.35D?5      5      5      5      .??5      ? 
 ? RowDefinitions
 5    
   ?? 5!      $??60 ?6   6*   ?? 5"      $??* ?6   6)   ?? 5#      $??* ?6   6)   ?? 5$      $??* ?6   6)   ?? 5%      $??* ?6   6)   ?? 5&      $??* ?6   6)   .+?5)   
   ? $??0??6   .+?5*      ?? -   5         ??Name$	 lbl??51       ? Cursor$
 Hand??5+      $??45??5,      $??0??5-      $??45??5.      $
??Left=?5/      $	??Top=?50      $??	5,-45,0,0q?51      .??52      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=?53      $??45??54      $??45??55      
???????$
??Left=?57      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 58      +  %Microsoft.Xaml.Behaviors.EventTrigger  59         	EventName$ MouseLeftButtonDown??6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5:      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   ?? *
CancelCM+   CommandParameter 5;   0   ??  ?? ElementName$	 lbl??5<      5>      ?? 5@      $??Forgot Password??5A      $
??Bold"?5B      
???????$??36(?5D      $??60??5E      $	??Top=?5F      $??Center=?5G      $??0,-5,0,0q?5H      5I      ? 5K   
   $??1??6   .+?5L      ?? -   5        $??txb_username_user??5M      $??16(?5O      $??Roboto)?5P      
??????????	#FFAFAFAF.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5S       % !MaterialDesignFloatingHintTextBox#??[ 5T      $??55??5U      $	??350??6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username??5V      .??6;    5W        5X      $ TextChanged??6%   . 5Y         60   ?? *UserNameChangedCM+ 5Z   0   ?? $ txb_username_user??5[      .??5\   *   5]      5^      ? 5`   
   $??2??6   .+?5a      ?? -   5        $??question_txt??5b       ?? 
IsReadOnly$
 True??5c      $??16(?5e      $??Roboto)?5f      
??????????	#FFAFAFAF#??[ 5j      $??55??5k      $	??350??6   $ Question??5l      ??5d      ?? *userForgotQuestion+5l      5m      ? 5o   
   $??3??6   .+?5p      ?? -   5        $??
txb_answer??5q      $ Your answer??5s      $
 True??5t      #??[ 5u      $??16(?5v      $??Roboto)?5w      $??55??5x      $	??350??6   
??????????	#FFAFAFAF??5r      ?? *userForgotAnswer+5z      5{      ? 5}   
   $??4??6   .+?5~      G? -   5        $??passb_new_password??5      $ Your new password??5?      $
 True??5?       ) %MaterialDesignFloatingHintPasswordBox#??[ 5?      $??Roboto)?5?      $??16(?5?      
??????????	#FFAFAFAF$??55??5?      $	??350??6   $y?Visible=?5?      $??Center=?5?      $
??Left=?5?      $??Center=?5?      $??Center=?5?       5?        5?      $ PasswordChanged??6%   . 5?         60   ?? *ForgotPasswordChangedCM+ 5?   0   ?? $ passb_new_password??5?      5?      ?? 5?      -   5        $??txb_new_password??5?      $
 True??5?      #??[ 5?      $??16(?5?      
??????????	#FFAFAFAF$y?Hidden=?5?      $??55??5?      $	??350??6   $??Center=?5?      $
??Left=?5?      $??Center=?5?      $??Center=?5?      ?? 5?      -   5         ??Name$ btn_new_pass??5?      
?????? 
?????? $??25??5?      $??25??5?      $??Bottom=?5?      $??Right=?5?      $??0,0,0,0q?5?      $??	0,0,40,15q?5?      ??5?      ?? 5?       ?? 
TargetType" ??6&   .R?5?      ?? $??25??5?      $??25??6(    ?? CornerRadius$ 5??5?      #??z??5?      ._?5?      ?? $??Center=?5?   !   $??Center=?5?   !   5?      5?      .??5?        -	   5          Name$ icon_new_pass??5?      $	 Eye=?5?      $??20??5?      $??20??5?      ???	#FFAFAFAF$??Center=?5?      5?      5?      ? 5?   
   $??5??5?      $	??115??5?      $??Center=?5?      $??Right=?5?      $	??429??5?      .+?5?      ?? -
   5        $??
btn_change??5?      $	??150??5?      $??40??5?       " MaterialDesignRaisedDarkButton#??[ 5?      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20??5?       ? ToolTip$7 1MaterialDesignRaisedDarkButton with Round Corners??5?      $??Center=?5?      $??Center=?5?      ???	#FF40CC6F???	#FF40CC6F??5?      ?? *ChangePasswordCM+.??5?      ?? $??Change??5?      $??18(?5?      $
??Bold"?5?      5?      5?      5?      5?      