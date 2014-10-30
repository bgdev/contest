import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Translator {

    private String sourceLanguage;
    private String targetLanguage;

    public Translator from(String sourceLanguage) {
        this.sourceLanguage = sourceLanguage;
        return this;
    }

    public Translator to(String targetLanguage) {
        this.targetLanguage = targetLanguage;
        return this;
    }

    public String translate(String word) {
        return encodeDecimal(decodeDecimal(word, sourceLanguage), targetLanguage);
    }

    private String encodeDecimal(int number, String alphabet) {
        List<Integer> list = new ArrayList<Integer>();
        char[] alphabetAsArray = alphabet.toCharArray();
        int base = alphabet.length();

        if (number == 0) {
            return String.valueOf(alphabetAsArray[0]);
        }

        while (number > 0) {
            int reminder = number % base;
            number = number / base;
            list.add(reminder);
        }

        Collections.reverse(list);

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < list.size(); i++) {
            builder.append(alphabetAsArray[list.get(i)]);
        }

        return builder.toString();
    }

    private int decodeDecimal(String word, String alphabet) {
        int base = alphabet.length();
        char[] wordArray = word.toCharArray();
        int number = 0;
        for (int i = 0; i < wordArray.length; i++) {
            int power = (wordArray.length - (i + 1));
            number += alphabet.indexOf(wordArray[i]) * Math.pow(base, power);
        }
        return number;
    }

}