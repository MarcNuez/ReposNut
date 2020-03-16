package operacions;

import static org.junit.Assert.assertEquals;

import org.junit.Before;
import org.junit.Test;

public class FactorialTest {
	Factorial fn;

	@Before
	public void crearClasse() {
		fn = new Factorial();
	}

	@Test
	public void test1() {
		assertEquals(120, fn.factorialIteratiu(5), 0.001);
	}
	
	@Test
	public void test2() {
		assertEquals(120, fn.factorialIteratiu(5), 0.001);
	}

	@Test(expected = IllegalArgumentException.class)
	public void getExceptionTest() {
		double valor = fn.factorialIteratiu(-3);
		System.out.println(valor);
	}
}
