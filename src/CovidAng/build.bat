call ng build  --aot=true --buildOptimizer=true --configuration=production
del ..\CovidWorkflow\CovidWorkflow\wwwroot\*.* /Q
copy dist\covidAng\*.* ..\CovidWorkflow\CovidWorkflow\wwwroot
rmdir dist /S /Q