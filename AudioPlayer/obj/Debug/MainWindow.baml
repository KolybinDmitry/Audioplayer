   M S B A M L   `   `   `  ����e  aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089wTclr-namespace:System.Windows.Controls.Ribbon;assembly=System.Windows.Controls.RibbonSystem.Windows.Controls.Ribbon  5   	   F BAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AudioPlayerAudioPlayer 5   	      AudioPlayer.MainWindow   5   	   _ribbonTclr-namespace:System.Windows.Controls.Ribbon;assembly=System.Windows.Controls.Ribbon  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AudioPlayer     5   	     � Title$  
MainWindow��5	   	   $	��390��6   $	��440��6)    � 
ResizeMode$ 	CanResize=�65   ���	#FFABC7E4.��5
      � .+�5   
   1   +System.Windows.Controls.Ribbon.RibbonButton  -   5          Name$ rButtonMixType��5      $��234,239,142,74q�6/   $��40��6d   $��40��6p      LargeImageSource$ /UI/overkill.png��6{   ���	#7FD7FF2F6�     5   
   -   5        $ rButtonFolder��5      $��138,239,238,74q�6/   $ /UI/folder.png��6c   $��40��6�   $��40��6�   ���	#7FD7FF2F6�     5   
   -   5        $ rButtonPrev��5      $��94,177,282,136q�6,   $ /UI/prev.png��6^   $��40��6~   $��40��6�   ���	#7FD7FF2F6�     5   
   -   5        $ rButtonPlayPause��5      $��190,177,186,136q�62   $ /UI/play.png��6j   $��40��6�   $��40��6�   ���	#7FD7FF2F6�     5   
   -   5        $ rButtonNext��5      $��278,177,98,136q�6-   $ /UI/next.png��6_   $��40��6   $��40��6�   ���	#7FD7FF2F6�   r� 5   
   -   5         r�Name$ mediaElement��5      $
��Left=�6-   $��56��6H   $��	10,10,0,0q�6T   $	��Top=�6g   $��55��6    J� OpacityMask 5      �� 5       �� Color$ 	#FF9E9E9E��6"    �� Opacity$ 0Q�64   5      �� 5   
   -   5         ��Name$ labelFileInfo��5      $��None audio track��6'   $��Center=�6B   $��
16,29,20,0q�6f   $	��Top=�6z   �� 5   
   -   5        $ labelTimeEnd��5      $��00:00��6&   $��Center=�66   $��201,68,20,0q�6Z   $	��Top=�6o   �� 5   
   -	   5        $ labelTimeStart��5      $��00:00��6(   $��Center=�68   $��16,68,205,0q�6\   $	��Top=�6q   �� 5   
   -
   5        	 ��Name$	 sliderTrackLine��5      $	��120��6*   $��152,70,148,235q�66   
 �� IsMoveToPointEnabled
 . 6N   �� 5   
   -   5        $	 sliderVolume��5      $��160,116,156,0q�6'   $	��Top=�6>    � Maximum$ 1Q�6    � LargeChange$	 0.1Q�6�   �� 5   
   -   5        $ labelFileInfo_Copy��5      $��Volume��6,   $��Center=�6=   $��20,134,16,0q�6a   $	��Top=�6v   5      5      