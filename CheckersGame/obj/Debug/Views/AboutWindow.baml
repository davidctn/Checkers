   M S B A M L   `   `   `  ����G  CCheckersGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CheckersCheckers  5   	       Checkers.AboutWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Checkers     5   	     � Title$  Checkers game��5   	   $��832.703��5	   	    � 
ResizeMode$ NoResize=�5
   	   ���#181235$��760.447��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��560* �6   �� 5      $
��257* �6   .+�5   
   �� -   5         ��Name$ Title1��5      $��50(�5      
�������$��Center=�5      $��Heavy"�5      $��Fonts/#Dosis)�5      $��-25,60,65,0q�5      $
��Wrap=�5       �� TextAlignment$ Center=�5      $��About the game��5      $	��Top=�5      $��95��6%   $	��520��61   5      �� 5!   
   -   5        $ Title2��5"      $��38(�5#      $ Center=�5$      
�������$��Center=�5&      $��Heavy"�5'      $��Fonts/#Dosis)�5(      $��0,512,115,0q�5)      $
��Wrap=�5*      $��About the developer��5+      $	��Top=�5,      $��86��6%   $	��452��61   �� 5.   
   -   5        $ Title3��5/      $��35(�50      
�������$��Center=�52      $��Medium"�53      $��Fonts/#Dosis)�54      $��-150,670,167,-25q�55      $
��Wrap=�56      $ Center=�57      $��Grupa : 292��58      $	��Top=�59      $��86��6%   $	��550��61    J� RenderTransformOrigin$ 
0.549,0.43&�6=   �� 5;   
   -   5        $ Title4��5<      $��35(�5=      $ Center=�5>      
�������$��Center=�5@      $��Medium"�5A      $��Fonts/#Dosis)�5B      $��-110,566,177,0q�5C      $
��Wrap=�5D      $!��Nume : Constantinescu David��5E      $	��Top=�5F      $��86��6%   $	��760��61   $��2��6=   �� 5H   
   -   5        $ Title5��5I      $��35(�5J      
�������$
��Left=�5L      $��Medium"�5M      $��Fonts/#Dosis)�5N      $ Center=�5O      $��	0,616,0,0q�5P      $.��(E-mail : constantinescudavid50@yahoo.com��5Q      $	��Top=�5R      $��86��6%   $	��770��61   $��2��6=   �� 5U   
   -   5        $ Content��5V      $��22(�5W      
�������$��Center=�5Y      $��Heavy"�5Z      $��Fonts/#Dosis)�5[      $��10,130,47,219q�5\      $
��Wrap=�5]      $ Center=�5^      $����Jocul este de regulă alcătuit dintr-o tablă de șah cu 8 x 8 pătrate colorate alternativ deschis și întunecat.Figurile de joc sunt 24 de discuri rotunde confecționate din lemn, pentru unul culoare albă și de culoare neagră pentru celălalt jucător.  Câmpul de joc îl constituie numai pătrățelele de culoare închisă, piesele de joc deplasându-se numai diagonal înainte, câte un pătrat, caz de excepție când poate sări peste piesa adversarului pe care o câștigă.Condiția de a putea sări piesa adversarului este ca în spatele piesei sărite să existe un câmp (pătrat) gol. Țelul jocului este de a ajunge pe ultimul rând de pătrățele din partea adversarului când piesele de joc suprapuse două câte două vor fi numite 'dame'.Aceste piese duble de joc pot sări diagonal de-a lungul tablei. A câștigat jocul acea persoană care a câștigat toate piesele adversarului sau l-a blocat.��5_      $	��760��5`      $��2��5a      5c      �� 5f   
   -   5         ��Name$ AboutExitButton��5g      $��40(�5h      $
��Exit��5i      
�������$��Medium"�5l      $��Fonts/#Dosis)�5m      $y�Visible=�5n      $��440,10,237,601q�5o      $��2��6)   ��5p      �� 5q       �� 
TargetType" ��6   .�5r      ��  �� Property � ��	 �� Value$	 Fonts/#Dosis)�6?   �� 5s       � ��	 �#2008a863   �� 5t       �@�Cursor$
	 Hand��6/   
 �� Triggers
 5u      P� 5v       P� Property �@J�IsMouseOver P� Value . . �5x      ��  � ��	 �#4c6bf56;   5y      5{      ��5}      �� 5~       �� 
TargetType" ��6"   .R�5      �� $
��Auto��6    �� CornerRadius$ 80��5�   !   #��z��5�   !   $��228,0,-194,13q�6T   ._�5�      �� $��Center=�6+   $��Center=�5�   /   5�      5�      5�      5�      5�      5�      