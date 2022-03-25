FROM southclaws/sampctl


# Install packages
ARG DEBIAN_FRONTEND=noninteractive
RUN apt-get update && apt-get install -y curl lib32stdc++6 libssl1.1:i386 libicu-dev:i386 

# Download and extract runtime (debian doesn't like the certificate, so we're using the -k option)
RUN mkdir -p /sampsharp/runtime \
  && curl -LJO https://deploy.timpotze.nl/packages/runtime_603_20220324.tar.gz \
  && tar xzf runtime_603_20220324.tar.gz -C /sampsharp/runtime \
  && rm -f runtime_603_20220324.tar.gz

ENV SAMPSHARP_RUNTIME /sampsharp/runtime
