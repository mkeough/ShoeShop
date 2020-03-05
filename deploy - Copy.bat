docker build -t shoe-shop1 .

docker tag shoe-shop1 registry.heroku.com/shoe-shop1/web

docker push registry.heroku.com/shoe-shop1/web

heroku container:release web -a shoe-shop1