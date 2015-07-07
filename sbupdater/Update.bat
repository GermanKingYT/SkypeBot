@echo off
cls
color 0a
echo Welcome, we are going to update the program in a few seconds!
timeout /t 2 /nobreak > nul
echo.
echo Killing skypebot task...
taskkill /im SkypeBot.exe /f > nul
echo Done!
echo.
echo Deleting old skypebot... 
del SkypeBot.exe
echo Done!
echo.
echo Downloading and Applying new update...
Updater.exe "%cd%/SkypeBot.exe"
echo Done!
cls
echo Done!
timeout /t 2 /nobreak > nul