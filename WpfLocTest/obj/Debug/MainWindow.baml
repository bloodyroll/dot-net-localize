   M S B A M L   `   `   `  ����E  AWpfLocTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfLocTest
WpfLocTest  5   	   G CAppLocalizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:AppLocalizer;assembly=AppLocalizerAppLocalizer 5   	       WpfLocTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfLocTest     5   	   IappLocalizer0clr-namespace:AppLocalizer;assembly=AppLocalizer     5   	     � SizeToContent$  Height=�5	   	    � Title$ 
MainWindow��5
   	   $	��600��6   $	��525��6)    � 	Resources 5      $  AppLocalizer.LanguageConverter   LanguageConverter)   #WpfLocTest.EnumDescriptionConverter  EnumDescriptionConverter)  #AppLocalizer.LanguageValueConverter  LanguageValueConverter/  )AppLocalizer.LanguageDescriptionConverter   LanguageDescriptionConverter  Data S� 
MethodName S� 
ObjectType   WpfLocTest.EnumUtility S� MethodParameters M� TypeName�� 5   
   %   &	        &	      &	 &     &	 9     &	 L       5      6-     5      6-     5      62     5      68   S� 5      $ GetValuesAndDescriptions��6.   "  5   !    5      M� 5      $ local:TestLangEnum��6&   5      5      .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� $��5q�6   $��
Languages:��6   �� 5   
   -   5         �� SelectedValuePath$	 Key��5       	 �� DisplayMemberPath$	 Value��6+   $��5q�5"      ��5      �� 
 �� Path$(
 "(appLocalizer:Translate.Languages)� �� Mode$ OneWay=�5"      �� 5$   
   $��5q�6   $��Translate.Dictionary:��5%      �� 5&   
   $ 
Horizontal=�6   .+�5(      �� $��5q�6   ��5)      �� $,
 &(appLocalizer:Translate.Dictionary)[1]� �� FallbackValue$ OneLangData�� �� 	Converter# [  5+      �� 5-   
   $��5q�6   $"��Translate.OneLangDictionary:��5.      �� 5/   
   $��5q�6   ��50      �� $3
 -(appLocalizer:Translate.OneLangDictionary)[1]�$ OneLangData���� 52   
   $��5q�6   $��
Enum test:��53      �� 54   
   -   5        $	��200��54      $��50��6   $��5q�6)   $��Change enum��55      56      �� 57   
   $��5q�6   ��58      �� *SomeEnumValue+# [ $ SomeEnumValue�� �� UpdateSourceTrigger$ PropertyChanged=�$ OneWay=��� 5;   
   .@�5<      �� $��1��6   .��5=      �� ��5>      ��    WpfLocTest.TestLangEnum   First �� Source# Z # [ $ 	LostFocus=�5A      �� 5B      $��2��6   .��5C      �� ��5D      ��    Second# Z # [ $ 	LostFocus=�5F      5G      �� 5I   
   $��5q�6   $	 Description��5J      $ Value��5K      ��5I      �� # [ 5M      �� 5N   
   $��14(�6   $��5q�6!   $ Value��5Q   !   ��5O   !   ��  %   WpfLocTest.EnumerationExtension  *M� *local:TestLangEnum++��5R      �� 5S       �� DataType$ local:TestLangEnum��6   .R�5T      �� ��6    �� *Value+# [ 6r   5U      5W      5X      5Y      