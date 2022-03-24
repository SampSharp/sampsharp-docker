FROM ubuntu:focal

# SA-MP server executable is a x86 application only
RUN dpkg --add-architecture i386

# Install packages
RUN apt-get update && apt-get install -y \
 lib32stdc++6 \
 curl \
 psmisc \
 libssl1.0:i386 \
 libicu-dev:i386 \
 unzip

# Download and extract server files
# Choose a more general directory name which does not contain any version
RUN curl -LJO http://files.sa-mp.com/samp037svr_R2-2-1.tar.gz \
 && tar xzf samp037svr_R2-2-1.tar.gz \
 && rm -f samp037svr_R2-2-1.tar.gz \
 && mv /samp03 /samp-svr \
 && cd samp-svr \
 && rm -rf include npcmodes/* filterscripts/* gamemodes/* server.cfg \
 && mv samp03svr samp-svr \
 && chmod 700 *

WORKDIR /samp-svr

COPY samp.sh /usr/local/bin/samp
COPY docker-entrypoint.sh /entrypoint.sh

RUN chmod +x /usr/local/bin/samp \
 && chmod +x /entrypoint.sh

COPY server.cfg server.cfg

# Download and extract runtime (debian doesn't like the certificate, so we're using the -k option)
RUN curl -kLJO https://deploy.timpotze.nl/packages/runtime_603_20220324.tar.gz \
  && tar xzf runtime_603_20220324.tar.gz \
  && rm -f runtime_603_20220324.tar.gz

# Download and extract sampsharp
RUN curl -LJO https://github.com/ikkentim/SampSharp/releases/download/0.10.0-alpha1/SampSharp-0.10.0-alpha1.zip \
  && unzip SampSharp-0.10.0-alpha1.zip \
  && rm -f SampSharp-0.10.0-alpha1.zip \
  && mv SampSharp-0.10.0-alpha1/* . \
  && rm -rf SampSharp-0.10.0-alpha1

ENTRYPOINT ["/entrypoint.sh"]

CMD ["samp", "start"]

EXPOSE 7777/udp
