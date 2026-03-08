Dette Repository viser, hvordan man i et Visual Studio Projekt i Asp.Net 9 C#, arbejder med Authentication og Authorization ved at vælge Individual User Accounts under projekt opsætningen.

Man skal være opmærksom på, at selvom selve Web App projektet her er et MVC Web App projekt, bruger ASP.NET som standard Razor Pages til Identity og altså ikke en klassisk MVC Controller, når man vælger Indivisual User Accounts under opsætning af Projektet. Så der er altså en sammenblanding af MVC teknk og Razor Page struktur i Projektet. 

Razor Page strukturen ses under mappen Identity. Se figuren herunder hvor der i Mappen Areas/Pages/Account/ ses Razor Page struktur for udvalgte sider hørende til User Account håndtering. 

<img width="730" height="395" alt="Account Mappe" src="https://github.com/user-attachments/assets/547a0d36-d4fa-42b0-ab9d-281d1b32785f" />

Til at begynde med vil de fleste af Razor page siderne vist i billedet herover ikke være en (synlig) del af ens Web App Projekt. Dette skyldes, at man i langt de fleste tilfælde ikke har behov for at ændre i nogle af filerne til User Account håndtering. Ønsker man at gøre en eller flere af filerne til User Account håndtering synlige, kan i Visual Studio opnå dette ved at gøre som vist i figuren herunder :

<img width="730" height="321" alt="Visual Studio Opsætning" src="https://github.com/user-attachments/assets/1e8d124a-006c-49a0-a1fe-0cdb1ccd4b32" />

Har kan man nu vælge en eller flere eller alle de filer, man måtte ønska skal være synlige i ens Projekt. Der er en del filer at vælge imellem, som det ses i figuren herunder. Så man skal nok ikke vælge dem alle sammen. Man kan altid på et senere tidspunkt vælge de filer, man skal bruge og som man ikke fik med i første omgang.

<img width="1024" height="801" alt="Identify Filer" src="https://github.com/user-attachments/assets/4e55e14a-d095-4976-9612-b745411af2f8" />

Bruger man et andet værktøj end Visual Studio kan man gøre det herover skrevne/vist ved brug af Coommand Line Interface kommandoer. 
Først skal værktøjet installeres, hvilket gøres ved at taste kommandoen herunder:

dotnet tool install -g dotnet-aspnet-codegenerator

Derefter skal selve scaffold kommandoen køres :

dotnet aspnet-codegenerator identity -dc MitProjekt.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"

I kommandoen herover er de 3 Razor Pages : Register, Login og Logout valgt til installation i ens projekt. Ønsker man ALLE Razor pages installeret i sit Projekt skriver man kommandoen herover uden at tilføje filnavne i slutningen af kommandoen. ALtså :

dotnet aspnet-codegenerator identity -dc MitProjekt.Data.ApplicationDbContext
