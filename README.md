# Stars

Stars is a simple game in which we set out on a space adventure with our fleet of spacecraft.

## Installation

Before building the application, we need to create a new migration and a new database via Entity Framework Core.

Make sure that stars.database is set as startup project.

Do the following in the Package Manager Console:
```package manager console
Add-Migration InitialCreate
Update-Database
```

Use the Visual Studio 2019 with .NET 5 to build Stars.

## Usage

Run stars.wpf.exe

1. Login/Register

a. Register a new player: enter the login in the "Login", the password in the "Hasło" box and press the "Rejestracja" button.

b. Login a player: enter the login in the "Login", the password in the "Password" box and press the "Login" button.

2. Game options - has four tabs:

a. "Start" - a view of the player's statistics: steel, steelworks level, ships.

b. "Budynki" - steelworks view - the current level of the building, the amount of steel needed to upgrade the building, and the current amount of steel.

Upgrade the building level by pressing the "Ulepsz hutę stali" button. You must have the amount of steel needed to upgrade.

Note: the higher the level of the steelworks, the more steel is produced.

c. "Flota" - spacecraft shipyard view - the current number of spaceships, the amount of steel needed to buy a ship, and the current amount of steel.

Buy spaceship by pressing the "Buy spaceship" button. You must have the amount of steel needed to buy.

d. "Przygoda" - go on an adventure! Choose a place in space where you want to send your fleet and CLICK there.

There are several events waiting for the player ;)

3. General notes: 

After increasing the level of the building / buying a ship, the change is visible only after reloading the game through another tab.
##
