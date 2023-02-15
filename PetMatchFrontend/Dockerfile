FROM node:18.14-alpine AS build
WORKDIR /PetMatchFrontend
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:alpine
COPY --from=build /PetMatchFrontend/dist/pet-match-frontend /usr/share/nginx/html
EXPOSE 8000
