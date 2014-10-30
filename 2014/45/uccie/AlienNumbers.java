import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class AlienNumbers {
    
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int numberOfTestCases = Integer.parseInt(br.readLine());
        Translator translator = new Translator();
        for (int testCase = 0; testCase < numberOfTestCases; testCase++) {
            String line = br.readLine();
            String[] arguments = line.split(" ");
            String translation = translator.from(arguments[1]).to(arguments[2]).translate(arguments[0]);
            System.out.println("Case #" + (testCase + 1) + ": " + translation);
        }
        br.close();
    }
    
}
