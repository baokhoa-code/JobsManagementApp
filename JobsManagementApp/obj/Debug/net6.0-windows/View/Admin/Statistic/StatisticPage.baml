   M S B A M L   `   `   `  ????  JobsManagementApp:    4JobsManagementApp.View.Admin.Statistic.StatisticPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5        N? 
FontFamily$  arial)?5
         StatisticVM ? DataContext# [  5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   ?? *StoreButtonNameCM+   CommandParameter 5   $   ??  ?? ElementName$ card1??  5       6$   ?? *
LoadViewCM+ 5   $   ?? $ 	mainFrame??5      .??5      ? $
??1270??6   $	??710??6    ? RowDefinitions 5   
   ?? 5      $??8* ?6   ?? 5      $	??92* ?6   .+?5    
   ?? $
??Left=?6   	 ?? Orientation$	 
Horizontal=?5!      $??57??5"      ???#f0f2f5.+?5$      #  MaterialDesignThemes.Wpf.Card  -   5        
  Name$
 card1??5(   %   $??57??5$   %   ???#f0f2f5+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=?5&   %      ShadowEdges$ Bottom=?5'   %   .??5)      ?? $??57??6   $??Summary??5*      
?????? 
???   ?
?????? $??0q?5.      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0??5/      ??50      ?? *LoadAllStatisticalCM+??51      ?? $ card1??52        53      -   5        $
 card2??58   &   $??57??53   "   ???#f0f2f5$ Depth2=?55   &   $ Bottom=?56   &   $??0q?57   &   .??59      ?? $??57??6   $??Ranking??5:      
?????? 
???   ?
?????? $??0q?5>      $ 0??5?      ??5@      ?? *LoadRankStatisticalCM+??5A      ?? $ card2??5B        5C      ???#f0f2f5$
??1126??5D      $ Depth2=?5E      $ Bottom=?5F      $??0q?5G      
??????    UniformCornerRadius$ 0Q?5I      5K      ? 5N   
   $??1??6   .+?5O       ? -   5          ?Name$ 	mainFrame??5O      $?? ??5P      $??0,0,2,0q?6   $	??650??60    5Q        5R      $ Loaded??6%   . 5S         60   ?? *LoadAllStatisticalCM+ 5T   0   ?? $ card1??5U      5W      5Y      ? 5[   
   $	??Top=?6   $	??720??5\      
?????? $??2??5^      .+?5_      ? -   5         ?Name$
 load??5d      $??2??5_      $??0q?5a      $	??Top=?5b      $??0,60,0,0q?5c      $??3??5e       ? IsIndeterminate 5`      ?? *	IsLoading+5e      ??5f      ?? 5g       ?? 
TargetType" ?6   .?5h      ??  ?? Property ? y? ?? Value$ 	Collapsed=?5i       ?? Triggers 5j      ?? 5k       ?? Binding 6&   ?? $
 load?? ?? Path$ IsIndeterminate? ?? Value True5l   &   .a?5m      ??  ? y?$ Visible=?5n   %   5o      5r      5t      5v      5y      