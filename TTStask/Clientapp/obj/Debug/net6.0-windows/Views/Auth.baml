   M S B A M L   `   `   `  ????D  @Clientapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Clientapp	Clientapp  5   P   ;"clr-namespace:Clientapp.ViewModelsClientapp.ViewModels  6z       Clientapp.Auth   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -	clientappclr-namespace:Clientapp     6P   9
viewmodels"clr-namespace:Clientapp.ViewModels     6z     ? Title$  Авторизация??5   	   $	??450??6   $	??800??6*   .??5      ? .+?5	   
   ?? -   5         ??Name$ Logintextbox??5	      $??Center=?6G   $??	0,172,0,0q?6d    ?? TextWrapping$
 Wrap=?6w   $	??Top=?6?   $	??150??6?   $??26??6?   ??6(   ??  ?? Path$ Curlogin?6?   ?? 5
   
   -   5         ??Name$ 	Logintext??5
      $??
Логин??6#   $
??Left=?63   $??255,172,0,0q?6N   $	??Top=?6c   $??35??6{   $??53??6?   ?? 5   
   -   5        $ Passtext??5      $??Пароль??6"   $
??Left=?63   $??255,217,0,0q?6N   $	??Top=?6c   $??35??6{   $??53??6?   ?? 5   
   -   5         ??Name$ Regbtn??5      $??Регистрация??6v   $
??Left=?6?   $??323,258,0,0q?6?   $	??Top=?6?   ??6!   ?? $ 
RegCommand???6E   ??  ?? ElementName$ Passbox??6?   ?? 5   
   -   5        $ Loginbtn??5      $??Вход??6x   $
??Left=?6?   $??400,258,0,0q?6?   $	??Top=?6?   $??59??6?   ??6#   ?? $ 
LogCommand???6G   ?? $ Passbox??6?   G? 5   
   -   5         G?Name$ Passbox??5      $??Center=?6)   $??	0,217,0,0q?6F   $	??Top=?6Y   $	??150??6q   $??26??6}   5      5      