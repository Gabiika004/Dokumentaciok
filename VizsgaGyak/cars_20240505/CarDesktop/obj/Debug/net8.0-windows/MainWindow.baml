   M S B A M L   `   `   `  ����E  ACarDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CarDesktop
CarDesktop  5          CarDesktop.MainWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:CarDesktop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $	��500��5	      $	��450��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��0��5      $��80��5      $��40��5      $��	10,10,0,0q�5      $
��Left=�5      $��Törlés��5      $��20(�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CarDataGrid��5      $��1��5       $��10q�5!         AutoGenerateColumns$ False��5"         SelectionMode$ Extended=�5#         ColumnHeaderStyle 5$      �� 5%       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5&      ��  �� Property � �� �� Value$ Center=�6C   5'      	   Columns	 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6<     5+      $
 License Plate Number��6L    6%   �� *LicensePlateNumber+6L     5,      $
 Brand��6?    6%   �� *Brand+6?     5-      $
 Model��6?    6%   �� *Model+6?     5.      $
 
Daily Cost��6C    6%   �� *	DailyCost+6C      RowDetailsTemplate 50      �� 51      .R�52      ��  �� Padding$ 10q�53      
�������$��0q�55      ._�56      ��  �� Orientation$ Vertical=�6%   .+�57      �� $ 
Horizontal=�6)   .+�58   "   �� $��Center=�59   %   $��12(�5:   %   $
��ID: ��5;   %   �� 5<   "   $��Center=�5=   %   $��16(�5>   %   
���p���5@   %   �� *Id+5A      �� 5B      $ 
Horizontal=�6)   .+�5C   "   �� $��Center=�5D   %   $��12(�5E   %   $��Rendszám: ��5F   %   �� 5G   "   $��Center=�5H   %   $��16(�5I   %   
���p���5K   %   �� *LicensePlateNumber+5L      �� 5M      $ 
Horizontal=�6)   .+�5N   "   �� $��Center=�5O   %   $��12(�5P   %   $��Brand:��5Q   %   �� 5R   "   $��Center=�5S   %   $��16(�5T   %   
���p���5V   %   �� *Brand+5W      5X      5Y      5Z      5\      5^      5_      