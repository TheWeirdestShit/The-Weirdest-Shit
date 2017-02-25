for i in *.jpg; 
	do convert "$i" -gravity center -extent 2048x2048 "$i";
done

for i in *.PNG; 
	do convert "$i" -gravity center -extent 2048x2048 "$i";
done
