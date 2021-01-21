package net.seymourpoler.tudumanager.domain;

import java.util.Random;

public class StringGenerator {
    public static String generate(Integer numberOfCharacters){
        final int letter_a = 97;
        final int letter_z = 122;
        Random random = new Random();
        StringBuilder buffer = new StringBuilder(numberOfCharacters);
        for (int i = 0; i < numberOfCharacters; i++) {
            int randomLimitedInt = letter_a + (int)(random.nextFloat() * (letter_z - letter_a + 1));
            buffer.append((char) randomLimitedInt);
        }
        return buffer.toString();
    }
}
