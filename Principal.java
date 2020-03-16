package operacions;

public class Principal {

	public static void main(String[] args) {
		Factorial fact = new Factorial();

		try {
			double valor = fact.factorialRecursiu(5);
			System.out.println(valor);
		} catch (IllegalArgumentException e) {
			System.out.println("No es poden fer servir nombres negatius.");
		}

	}
}
