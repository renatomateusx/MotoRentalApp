docker network create mynetwork

docker build -t motorrentalapp .  

docker stop motorrentalapp
docker rm motorrentalapp
docker stop postgres
docker rm postgres

docker run -d \
  --name postgres \
  --network mynetwork \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=123456 \
  -e POSTGRES_DB=MotoRentalDB \
  -p 5432:5432 \
  postgres


docker run -d -p 5555:8080 --name motorrentalapp --network mynetwork motorrentalapp

docker ps
docker logs motorrentalapp

# docker stop motorrentalapp
# docker rm motorrentalapp
# docker stop postgres
# docker rm postgres

# docker run -d -p 5555:8080 --name motorrentalapp --network mynetwork motorrentalapp

# docker build -t motorrentalapp .    

# docker logs motorrentalapp