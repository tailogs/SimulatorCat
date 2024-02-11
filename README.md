# Симулятор консольного кота

Для запуска скачайте один из релизов или скомпилируйте сам проект используя комманды ниже.

1. Перейдите в каталог прокта и введите следующую командуд

```shell
javac -d bin ./src/*
```

2. Далее введите эту команду и если код запуститься, значит все работает

```shell
java -classpath .\bin Main
```

3. Скомпилируйте программу в `jar` файл

```shell
 jar -cmf .\manifest.mf SimulatorCat.jar -C bin .
```

4. Запуск программы осуществляется командой

```shell
java -jar .\SimulatorCat.jar
```

Теперь вы можете распространять `SimulatorCat.jar` файл, 
но чтобы другой человек его запустил вам нужно показать последнюю команду выше.
Его задача вводить эту команду для запуска программы.
Так же у него должна быть `jvm java` и очень желательно `21` версии.