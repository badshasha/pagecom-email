Microservice sends email using sendinblue smtp server 

this microserver not dirrectly connect with any other microserver but RabbitMQ.
rabbitMq connect with the cart micorserver 


cart ----> exchange(pagecom) ----> queue(pagecom) ----> email (this microserver)
BOTH microservice contain shareing information  in a pagecom.commom namespace


