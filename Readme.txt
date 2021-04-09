
Jag har utökat min applikation med ett hamsterspa. Lade till en klass med properties med Id och AmountInArea. 
I spat så kan det vara max 4 st hamstrar och de checkas in på spat varje timme och 24 minuter över. De befinner sig i spat i 50 min
och sedan checkas de ut igen. Det kan endast vara antingen killar eller tjejer i spat. 

Jag har valt att tidsbasera händelsen, för att få till en bra logik i applikationen. Metoden som checkar in hamstrarna kallar först på en 
metod som kollar om spat är ledigt. Finns där inga hamstrar, så checkar den in 4 st hamstrar som nu finns i dagburar. 
Jag valde att ta dem i OrderBy() antalet gånger de varit i spat, för att få en viss ordning på inheckningen. 
Sedan tar den ThenBy() ålder, för att jag ville att de skulle vara i ungefär samma ålder. 

För att få jämnt mellan könen, så valde jag att ta ut en lång lista på alla hamstrar, sedan ta ut de 4 översta tjejerna och 4 översta killarna
i varsin lista. Jag räknar sedan ut average på antalet gånger de varit i spat, för att sen välja den grupp som har lägst average. 
Detta är för att hamstrarna kan hinna vara i spat fler än en gång per dag. Så om killarna har en lägre average amount of spavisits, 
så kommer de att få checkas in i spat. 

Jag väljer att kalla på ett event som skriver ut på skärmen vilken aktivitet som hamstern flyttas till. Varje gång en hamster checkas in på spat, så ökar propertin 
med +1 på AmountInArea. När alla hamstrar checkas ut från spat, så sätts AmountInArea till 0 igen.  