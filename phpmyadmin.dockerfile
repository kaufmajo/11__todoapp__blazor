FROM phpmyadmin:latest

ENV PMA_HOST=mariadb
ENV PMA_PORT=3306
#ENV PMA_USER=DEFAULTVALUE			# if set, it will be used to connect to the database with autologin
#ENV PMA_PASSWORD=DEFAULTVALUE		# if set, it will be used to connect to the database with autologin

EXPOSE 80