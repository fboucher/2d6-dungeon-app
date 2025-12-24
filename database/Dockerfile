FROM mysql:8.0

# Default database name; can be overridden at runtime
ENV MYSQL_DATABASE=db2d6
ENV MYSQL_ROOT_HOST=%

# Ship schema and seed data inside the image so containers start ready-to-use
COPY database/scripts/ /docker-entrypoint-initdb.d/

EXPOSE 3306
