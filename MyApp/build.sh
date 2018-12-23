docker build -t aspnetapp .
docker stop myapp
docker rm myapp
docker run -d -p 8080:80 --name myapp aspnetapp