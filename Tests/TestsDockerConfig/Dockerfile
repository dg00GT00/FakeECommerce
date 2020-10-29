FROM mcr.microsoft.com/mssql/server:2019-latest
# Create a config directory
WORKDIR /usr/testsconfig
# Bundle config source
COPY SqlServerConfig ./
# Grant permissions for to our scripts to be executable
USER root
RUN chmod +x ./entrypoint.sh
RUN chmod +x ./configure-db.sh
# Switch back to defualt user
USER mssql
ENTRYPOINT ["/usr/testsconfig/entrypoint.sh"]
