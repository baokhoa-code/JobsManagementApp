   M S B A M L   `   `   `  ????L  HJobsManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:JobsManagementApp.View.ShareJobsManagementApp.View.Share  5   	   /    )JobsManagementApp.View.Share.Notification   5   	   4local*clr-namespace:JobsManagementApp.View.Share  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? WindowStyle$
  None=?5	   	    ? 
ResizeMode$ NoResize=?5
   	   $	??600??5   	   $	??600??6    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ Notification??5   	   $??SVN-Product Sans)?5   	   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??30 ?6   6*   ?? 5      6   .+?5   
   ? $??0??6   .+?5      (  "MaterialDesignThemes.Wpf.ColorZone  -   5           Mode$
 Dark=?5   '   .??5      ? 
???OO/?$??30??62   .+?5      ?? -   5        $??
txbl_Title??5       $??35 0 0 0q?5       $??Thông báo??5       $??15(?5       $??SVN-Product Sans)?5       $??Center=?5        $
??Left=?5!       5"      ?? 5$      -   5        $??	btn_Close??5%      $??20??5&      $??20??6)   $??0 0 3 0q?5'      
??? E?? J? Opacity$	 0.8Q?5)      
??? E??$??Right=?5+       /  +MaterialDesignFloatingActionMiniLightButton#??[  5,      .??5-      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=?62   $??15??6?   $??15??6K   5.      ?? 50      -   5        $??btn_Maximize??50      $??0 0 27 0q?51      
???????
???????$??20??54      $??20??6)   $	 0.8Q?64   $??Right=?55      #??[  56      .??57        $ WindowMaximize=?62   $??15??6H   $??15??6T   58      ?? 5:      -   5        $??btn_Minimize??5;      $??0 0 51 0q?5<      
???????
???????$??20??5?      $??20??6)   $	 0.8Q?64   $??Right=?5@      #??[  5A      .??5B        $ WindowMinimize=?62   $??15??6H   $??15??6T   5C      5D      5E      5F      ? 5H   
   $??1??6    5I      ?? 5J      6"   ?? 5K      $??70 ?6    6.   .+?5N      ? $??0??6   $??5 5 5 5q?5O      .+?5P      ?? -   5        $??txbl_notification??5V      $??30(?5Q       ?? TextAlignment$ Justify=?5R      	 ?? TextWrapping$
	 Wrap=?5S      $??Center=?5T      $??Center=?5U      $	??600??5V   5   $	??500??6A   $??
10,0,10,10q?6N   .??6c   5W      5X      ? 5Z      $??1??6   .+?5[      ?? $??50??6   $	??120??5\      
????+??
????+??
 ?? CornerRadius$
 30??5_      ._?5`      ?? -   5        $??btn_confirm??5e      
?????? 
?????? $??50??5b      $	??110??5c      $??30(?5d      .??5f   7   OK5h      5i      5j      5k      5l      5m      