#remove swarm 
docker swarm leave --force

#stop all containers

docker kill $(docker ps -q)

docker rm $(docker ps -a -q)

#docker rmi -f $(docker images -q) <- questo cancellava tutto
docker rmi -f identity
docker rmi -f catalog

docker rm $(docker ps -a -f status=exited -q)

#cleanup volumes
docker volume prune --force