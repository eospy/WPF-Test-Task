   M S B A M L   `   `   `  ????D  @Clientapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Clientapp	Clientapp  5   	   ;"clr-namespace:Clientapp.ViewModelsClientapp.ViewModels  6/       Clientapp.Main   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Clientapp     5   	   9
viewmodels"clr-namespace:Clientapp.ViewModels     6/   -   5          ? Title$
  Main??5	   	   $	??450??6   $	??800??6#    J? InputBindings 5
      d? 5   
    d? MouseAction$ 	LeftClicke?6    ?? CommandParameter$ 	LeftClick??5       ?? Command 5      ?? *MouseButtonCommand+5      d? 5   
   $ 
RightClicke?6   $ 
RightClick??5       5      ?? *MouseButtonCommand+5      .??5      ? .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 Grid??5      $??225,36,225,187q?6E   ??6!   ??  ?? Path$ Events?6E   ?? 5   
   -   5         ??Name$ Startbtn??5      $??Запуск??6#   $
??Left=?6`   $??225,264,0,0q?6{   $	??Top=?6?   $??40??6?   $??60??6?   ??64   ?? $ Startbuttoncommand?6?   ?? 5   
   -   5         ??Name$ Counter??5      $
??Left=?6H   $??290,264,0,0q?6c   $
??Wrap=?6x   $	??Top=?6?   $??40??6?   $??40??6?   $??24(?6?   ??6%   ?? $ Eventscount?6?   ?? 5   
   -   5        	 ??Name$	 MousemoveCheckBox??5      $??	mousemove??6T   $
??Left=?6h   $??335,262,0,0q?6?   $	??Top=?6?   
 d? 	IsChecked
 6.   ?? *CheckMouseMove+6?   ?? 5   
   -   5        $	 LeftbtnCheckBox??5      $??
leftbutton??6R   $
??Left=?6g   $??335,277,0,0q?6?   $	??Top=?6?   
 6,   ?? *CheckMouseLeft+6?   ?? 5   
   -   5        $	 RightbtnCheckBox??5      $??rightbutton??6T   $
??Left=?6j   $??335,292,0,0q?6?   $	??Top=?6?   
 6-   ?? *CheckMouseRight+6?   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
Pickerprev??5      $
??Left=?6)   $??433,256,0,0q?6D   $	??Top=?6Y   $??28??6q   $	??125??6}      SelectedDate 6?   ?? $ 	Starttime? ? 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox ?? 
TargetType ?? Property ?? Value ?? RelativeSource ?? AncestorType ?? StringFormat??%?   '        ?? 5      "  6   .?5      ??  ? ?? 5       ?? 5!      .R?5"   "   ?? ??6*   ?? $ SelectedDate? ??  
DatePicker$ MM/dd/yy H:mm:ss??5#      5%      5&      5'      5(        5)   
   -	   5        $ 
Pickerpost??5)      $
??Left=?6)   $??433,292,0,0q?6D   $	??Top=?6Y   $??28??6q   $	??125??6}    6?   ?? $ Endtime? 5*      ??%?   '        ?? 5+      "  6   .?5,      ??  ? ?? 5-      ?? 5.      .R?5/   "   ?? ??6*   ?? *SelectedDate+ ?? "  $ MM/dd/yy H:mm:ss??50      52      53      54      55      ?? 56   
   -
   5        $ Filterbydate??56      $??Filter by date??6P   $
??Left=?6i   $??459,325,0,0q?6?   $	??Top=?6?   ??6'   ?? *Filterbydatecommand+6?   ?? 57   
   -   5        $ Cancelfilters??57      $??Cancel filters??6Q   $
??Left=?6j   $??348,325,0,0q?6?   $	??Top=?6?   ??6(   ?? *Cancelfilterscommand+6?   59      5:      