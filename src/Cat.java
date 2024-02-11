import java.util.InputMismatchException;
import java.util.Random;
import java.util.Scanner;

public class Cat {
    Random random = new Random();
    Scanner scanner = new Scanner(System.in, "Cp866");
    int health = 100; // здоровье
    int satisfied = 100; // удовлетворенный
    int rest = 100; // отдохнул
    int hunger = 100; // голод
    int purity = 100; // чистота
    int wastes = 100; // туалет
    int daysLife = 0;   // количество дней жизни
    String name;

    public Cat() {
    }

    public void birth() {
        System.out.print("Котик рождается, как вы его назовете?\n> ");
        this.name = scanner.nextLine();
    }

    public void live() {
        boolean livePet = true;
        while (livePet) {
            System.out.println("ПИТОМЕЦ: ");
            System.out.println("===[ " + name + " ]==");
            System.out.println("<<< Здоровье: " + health + " >>>");
            System.out.println("1. Ласкать        | " + "Удовлетворенность: " + satisfied);
            System.out.println("2. Играться       | " + "Удовлетворенность: " + satisfied);
            System.out.println("3. Уложить спать  | " + "Отдых:             " + rest);
            System.out.println("4. Покормить      | " + "Голод:             " + hunger);
            System.out.println("5. Помыть         | " + "Чистота:           " + purity);
            System.out.println("6. Поменять лоток | " + "Туалет:            " + wastes);

            System.out.print("> ");
            byte c = 0;
            try {
                c = scanner.nextByte();
            } catch (InputMismatchException e) {
                c = 25;
                clearConsole();
                System.out.println("Ошибка ввода: введено некорректное значение.");
                continue;
            }

            tick();

            if (random.nextBoolean())
                voice();

            clearConsole();

            switch (c) {
                case 1:
                    pet();
                    break;
                case 2:
                    play();
                    break;
                case 3:
                    sleep();
                    break;
                case 4:
                    eat();
                    break;
                case 5:
                    wash();
                    break;
                case 6:
                    toilet();
                    break;
                default:
                    System.out.println("[Выбранный пункт отсутствует]");
            }
            livePet = death();
        }
    }

    private void tick() {
        for (int i = 0; i < 10; i++) {
            health -= (int) Math.round(random.nextDouble());
            satisfied -= (int) Math.round(random.nextDouble());
            rest -= (int) Math.round(random.nextDouble());
            hunger -= (int) Math.round(random.nextDouble());
            purity -= (int) Math.round(random.nextDouble());
            wastes -= (int) Math.round(random.nextDouble());
        }
    }

    public void sleep() {
        System.out.println(name + " спит...");
        rest += random.nextInt(30);
        if (rest > 100) rest = 100; // восстанавливаем отдых, но не больше 100
        addHealth();
    }

    public void eat() {
        System.out.println(name + " ест...");
        hunger += random.nextInt(30);
        if (hunger > 100) hunger = 100; // увеличиваем голод, но не больше 100
        addHealth();
    }

    public void wash() {
        System.out.println(name + " моется...");
        purity += random.nextInt(30);
        if (purity > 100) purity = 100; // увеличиваем чистоту, но не больше 100
        addHealth();
    }

    public void play() {
        System.out.println(name + " играется...");
        satisfied += random.nextInt(30);
        if (satisfied > 100) satisfied = 100; // увеличиваем удовлетворенность, но не больше 100
        addHealth();
    }

    public void toilet() {
        System.out.println(name + " ходит в туалет...");
        wastes += random.nextInt(30);
        if (wastes > 100) wastes = 100; // увеличиваем туалет, но не больше 100
        addHealth();
    }

    public void pet() {
        System.out.println(name + " доволен лаской...");
        satisfied += random.nextInt(30);
        if (satisfied > 100) satisfied = 100; // увеличиваем удовлетворенность, но не больше 100
        addHealth();
    }

    String[] catVoice = {"Мур", "Мяу", "Мррр", "Мяур", "Рррррррр", "Рар"};

    public void voice() {
        int randomIndex = random.nextInt(catVoice.length);
        String voice = catVoice[randomIndex];
        System.out.println(voice + " =>-<=");
    } // говорить

    public void addHealth() {
        health += random.nextInt(30);
        if (health > 100) health = 100;
    }

    public boolean death() {
        if (rest <= 0) {
            System.out.println("Котик устал жить и умер");
            return false;
        } else if (hunger <= 0) {
            System.out.println("Котик умер голодным");
            return false;
        } else if (purity <= 0) {
            System.out.println("Котик сильно заболел и умер");
            return false;
        } else if (satisfied <= 0) {
            System.out.println("Котику стало грустно и он сбежал");
            return false;
        } else if (wastes <= 0) {
            System.out.println("Котику негде было ходить в туалет и он убежал на улицу");
            return false;
        } else if (health <= 0) {
            System.out.println("Котик умер из-за слабого здоровья");
            System.out.println("Прижил котик: " + daysLife);
            return false;
        }
        daysLife++;
        return true;
    }

    public static void clearConsole() {
        for (int i = 0; i < 50; i++)
            System.out.println();
    }
}
