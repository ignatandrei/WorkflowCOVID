call ng build  --aot=true --buildOptimizer=true --configuration=production
del ..\CovidWorkflow\CovidWorkflow\wwwroot\*.js /Q
del ..\CovidWorkflow\CovidWorkflow\wwwroot\*.css /Q
del ..\CovidWorkflow\CovidWorkflow\wwwroot\index.html /Q

copy dist\covidAng\*.* ..\CovidWorkflow\CovidWorkflow\wwwroot
rmdir dist /S /Q