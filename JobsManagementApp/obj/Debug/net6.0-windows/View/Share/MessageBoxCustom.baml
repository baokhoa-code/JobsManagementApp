   M S B A M L   `   `   `  ????  JobsManagementApp3    -JobsManagementApp.View.Share.MessageBoxCustom   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  MessageBoxWindow??5   	   $	??200??5	   	   $	??350??5
   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? WindowStyle$
 None=?5   	   
??????  ? SizeToContent$ WidthAndHeight=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? Topmost$
 True??5   	    ? AllowsTransparency$
 True??5   	    ? ShowInTaskbar$ False??5   	      MaterialDesignBody#???   5   	   $??Regular"?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	   	   TextRenderingMode$
	 Auto=?5   	     MaterialDesignFont#???  5   	   .??5      ?? 
 ?? CornerRadius$
 10??6   
???   ?$	??1.2q?5      
???????._?5   
   ?  ? RowDefinitions 5      ?? 5      $??30 ?6    ?? 5      $	??180 ?6     ? ColumnDefinitions 5!      ?? 5"      $
??197* ?6#   ?? 5#      $
??295* ?6#   .+?5&      ?? -   5         ??Name$ BackGroundTittle??5'      $??0??5&      $??2??5(      
??????$
 	10,10,0,0??5*      ._?5+      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=?6&   
??????  ! PrimaryHueDarkForegroundBrush#???  5-   &   .??5.      ??  ?? Orientation$ 
Horizontal=?6!   $
??Left=?5/   !   $??Center=?50   !   .+?51      ?? $#??/Resource/images/suitcase.png??6    $??23??52       $??23??53       $??8,0,0,0q?6,   ?? 54      -   5         ??Name$ txtTitle??54   $   $??15??55   $   $??8,4,0,0q?56   $    ?? TextAlignment$ Center=?57   $   $??14(?58   $   Title69   59      5:      5;      ?? 5<      $??Right=?6   $??0,5,5,0q?5=      $	??Top=?5>      $??1??5?      .+?5@      ?? -   5         ??Name$ btnClose??5@      $??20??5B      $??20??5C      
???????  PrimaryHueDarkBrush#???  5E       * &MaterialDesignFloatingActionDarkButton#??[ 5F      .??5G      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=?6.   5H      5I      ? 5J      $??1??6   $??2??5K      .+?5L      ? $??20q?6    5M      ?? 5N      $??90 ?6(   ?? 5O      $??50 ?6(   .+?5Q      ? $??0??6   .+?5R      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  $??Center=?6>   $??80??5S      C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5T      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5U   "      Kind$ FadeIn=?6B     5V   "   $ SlideInFromBottom=?6B   .??5X      ?? $ 
Horizontal=?6)   .+?5Y   "   ?? -   5         ??Name$ 
ImgMessage??5Y   (   $??50??5Z      $??20 0 0 5q?5[      ?? 5\   "   -   5         ??Name$ 
txtMessage??5\   *   $??0q?5]   *    ?? 
IsReadOnly$
 True??5^   *    ?? TextWrapping$
 Wrap=?5_      $	??240??5`      $??65??5a      $??Center=?5b      $??0??5c      $??	25,23,5,5q?5d      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  ??5e      $??18(?5f      5g      5h      5i      ? 5j      $??1??6   $??0,10,0,5q?5k       5l      ?? 5m      $??* ?6/   ?? 5n      $
??auto ?6/   ?? 5o      $
??auto ?6/   ?? 5p      $??* ?6/   .+?5s      ?? -   5        $ btnOk??5s   !   $??1??5u   !     MaterialDesignRaisedButton#??[ 5v   !   
???   ?$??	20 2 20 0q?5x   !   $??95??5y   !   $??OK??5z   !   ?? 5|      -   5        $ 	btnCancel??5|   !   ???	#FF92A9C0$??2??5   !   #??[ 5?   !   
???   ?$??	20 2 20 0q?5?   !   $??75??5?   !   $??Close??5?   !   ?? 5?      -   5        $ btnYes??5?   !   $??1??5?   !   #??[ 5?   !   
???   ?$??	20 2 20 0q?5?   !   $??80??5?   !   $	??Yes??5?   !   ?? 5?      -	   5        $ btnNo??5?   !   ???	#FF92A9C0$??2??5?   !   #??[ 5?   !   
???   ?$??	20 2 20 0q?5?   !   $??80??5?   !   $??No??5?   !   5?      5?      5?      5?      5?      5?      