   M S B A M L   `   `   `  ????L  HJobsManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:JobsManagementApp.View.GeneralJobsManagementApp.View.General  5   	   +    %JobsManagementApp.View.General.Splash   5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   >local,clr-namespace:JobsManagementApp.View.General     5   	     ? WindowStyle$
  None=?5	   	    ? WindowStartupLocation$ CenterScreen=?5
   	    ? WindowState$ Normal=?5   	    ? AllowsTransparency$
 True??5   	   
??????  ? 
ResizeMode$ NoResize=?5   	    ? Icon$# /Resource/images/suitcase.png??5   	    ? Title$ Splash??5   	   $	??330??6   $	??650??6%    ? Triggers 5      :? 5   
    :? RoutedEvent$ Loaded??6   .[?5      ?? .??5      ?? 	 g? Duration$	 00:00:35D?6   
 ?? TargetProperty$
 Opacity?61   .??5      W?  W? From 06&   	 W? To 16/   5      5      5      .??5      ? .+?5   
   ??  ?? CornerRadius$ 25??6    ?? Padding$ 0,0,0,10q?6#   ??5      ?? 5       j? Stretch$
 Fill=?6    ?? ImageSource$+ %/Resource/images/backgroundSplash.jpg??6,   ._?5!      ?  ? IsIndeterminate$
 True??5"      $??381,198,69,116q?6(   ???	#FF4AF169$
}?True??6W    J? Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$      5&      5'      5(      5+      