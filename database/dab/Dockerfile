FROM mcr.microsoft.com/azure-databases/data-api-builder:latest
WORKDIR /App
# Bundle the static DAB configuration; connection string provided at runtime
COPY database/dab-config.json ./dab-config.json
CMD ["--ConfigFileName", "/App/dab-config.json"]
