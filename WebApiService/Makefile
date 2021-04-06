image:
	docker build -f Dockerfile .. -t webapiservice:latest
run:
	docker run --name webapiservicecontainer -p 80:80 -it webapiservice:latest

up: image run

start: run