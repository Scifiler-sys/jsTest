from node:alpine as build

workdir /app

copy package.json ./
copy package-lock.json ./

run npm install

copy . ./

run npm run build

from nginx:alpine

copy --from=build /app/build /usr/share/nginx/html

RUN rm /etc/nginx/conf.d/default.conf
# replace with custom one
COPY nginx/nginx.conf /etc/nginx/conf.d

expose 80

cmd ["nginx", "-g", "daemon off;"]

# Run command
# docker run -d -p 80:80 -t react:0.3