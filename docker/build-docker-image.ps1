docker build -t identity  -f "..\src\Identity\VivaioInCloud.Identity.Api\Dockerfile" "..\"

docker build -t catalog  -f "..\src\Catalog\VivaioInCloud.Catalog.Api\Dockerfile" "..\"

docker build -t notification  -f "..\src\Notification\VivaioInCloud.Notification.Api\Dockerfile" "..\"