using UnityEngine;
using System.Collections;

public class NotesIterator {
	
	private IEnumerator enumerator;
	private bool hasMore;
	private float time;
	private int column;
	private int fraction;
	private NotesScript.NotesType type;
	
	public NotesIterator(int[] data) {
		this.enumerator = data.GetEnumerator();
		advance();
	}
	
	private void advance() {
		hasMore = enumerator.MoveNext();
		if (hasMore) {
			time = (int)enumerator.Current / 1000f;
		}
		hasMore = enumerator.MoveNext();
		if (hasMore) {
			column = (int)enumerator.Current;
		}
		hasMore = enumerator.MoveNext();
		if (hasMore) {
			fraction = (int) enumerator.Current;
		}
		type = NotesScript.NotesType.TAP; // TODO - taps only
	}
	
	public bool hasNext() {
		return hasMore;
	}
	
	public float nextTime() {
		return time;
	}
	
	public void next(out float time, out int column, out int fraction, out NotesScript.NotesType type) {
		time = this.time;
		column = this.column;
		fraction = this.fraction;
		type = this.type;
		advance();
	}
	
	public void next(NotesScript note) {
		note.Setup(time, column, fraction, type);
		advance();
	}
}

public class NotesData : MonoBehaviour {
	
	// TODO - this is just temporary until I write a .sm parser	
	// SMOOOCH_5_MOD is modified to remove 8th notes and a few high notes for Mode 5
	public static int[] SMOOOOCH_5_MOD = {
		1958, 0, 4,
		2297, 1, 4,
		4332, 0, 4,
		4671, 0, 4,
		5010, 1, 4,
		7045, 0, 4,
		7384, 3, 4,
		7723, 1, 4,
		9757, 0, 4,
		10775, 3, 4,
		11114, 0, 4,
		11453, 0, 4,
		12131, 2, 4,
		12470, 3, 4,
		12809, 0, 4,
		13148, 3, 4,
		13487, 2, 4,
		13826, 1, 4,
		14165, 0, 4,
		14505, 3, 4,
		14844, 1, 4,
		15183, 2, 4,
		15522, 0, 4,
		15861, 3, 4,
		16200, 2, 4,
		16539, 1, 4,
		16878, 0, 4,
		17217, 3, 4,
		17556, 2, 4,
		17895, 1, 4,
		18235, 0, 4,
		18574, 3, 4,
		18913, 1, 4,
		19252, 2, 4,
		19591, 3, 4,
		19930, 0, 4,
		20269, 2, 4,
		20608, 1, 4,
		20947, 3, 4,
		21286, 0, 4,
		21626, 2, 4,
		21965, 1, 4,
		22304, 0, 4,
		22643, 1, 4,
		22982, 0, 4,
		23321, 1, 4,
		23660, 0, 4,
		23999, 3, 4,
		24338, 2, 4,
		24677, 1, 4,
		25016, 3, 4,
		25356, 0, 4,
		25695, 2, 4,
		26034, 1, 4,
		26373, 0, 4,
		26712, 3, 4,
		27051, 2, 4,
		27390, 1, 4,
		27729, 0, 4,
		28068, 3, 4,
		28407, 2, 4,
		28746, 1, 4,
		29086, 0, 4,
		29425, 3, 4,
		29764, 2, 4,
		30103, 1, 4,
		30442, 0, 4,
		30781, 1, 4,
		31120, 2, 4,
		31459, 1, 4,
		31798, 2, 4,
		32137, 0, 4,
		33494, 2, 4,
		33833, 1, 4,
		34172, 3, 4,
		34511, 0, 4,
		34850, 3, 4,
		35528, 1, 4,
		35867, 0, 4,
		36207, 3, 4,
		36885, 1, 4,
		37224, 0, 4,
		37563, 3, 4,
		38241, 1, 4,
		38580, 0, 4,
		38919, 3, 4,
		39597, 1, 4,
		39937, 0, 4,
		40276, 3, 4,
		40954, 1, 4,
		41293, 0, 4,
		41632, 3, 4,
		42310, 1, 4,
		42649, 3, 4,
		42988, 0, 4,
		43667, 1, 4,
		44006, 3, 4,
		45023, 2, 4,
		45362, 1, 4,
		45701, 0, 4,
		46040, 2, 4,
		46379, 1, 4,
		46718, 3, 4,
		47057, 3, 4,
		47397, 3, 4,
		47736, 2, 4,
		48075, 1, 4,
		48414, 0, 4,
		48753, 2, 4,
		49092, 1, 4,
		49431, 0, 4,
		49770, 2, 4,
		50109, 1, 4,
		50448, 0, 4,
		50787, 1, 4,
		51127, 0, 4,
		51466, 2, 4,
		51805, 1, 4,
		52144, 0, 4,
		52483, 2, 4,
		52822, 1, 4,
		53161, 0, 4,
		53500, 3, 4,
		53839, 1, 4,
		54857, 3, 4,
		55874, 2, 4,
		56213, 3, 4,
		56552, 1, 4,
		58587, 0, 4,
		59943, 0, 4,
		61299, 0, 4,
		62656, 0, 4,
		64012, 3, 4,
		65368, 3, 4,
		65708, 3, 4,
		66386, 0, 4,
		66725, 2, 4,
		67064, 0, 4,
		67403, 0, 4,
		67742, 3, 4,
		69099, 3, 4,
		69438, 0, 4,
		70455, 3, 4,
		70794, 0, 4,
		71811, 0, 4,
		72150, 3, 4,
		73168, 0, 4,
		73507, 3, 4,
		74524, 3, 4,
		74863, 0, 4,
		75202, 0, 4,
		75541, 2, 4,
		75880, 1, 4,
		76219, 1, 4,
		76559, 0, 4,
		76898, 1, 4,
		77576, 1, 4,
		77915, 0, 4,
		78254, 3, 4,
		78932, 1, 4,
		79271, 3, 4,
		79610, 0, 4,
		80289, 2, 4,
		80628, 0, 4,
		80967, 3, 4,
		81645, 2, 4,
		81984, 3, 4,
		82323, 0, 4,
		83001, 2, 4,
		83340, 0, 4,
		83680, 3, 4,
		84358, 1, 4,
		84697, 0, 4,
		85036, 3, 4,
		85714, 2, 4,
		86053, 0, 4,
		86392, 1, 4,
		87070, 1, 4,
		87410, 0, 4,
		87749, 0, 4,
		88427, 2, 4,
		88766, 1, 4,
		89105, 0, 4,
		89783, 1, 4,
		90122, 0, 4,
		90461, 3, 4,
		91140, 1, 4,
		91479, 1, 4,
		91818, 0, 4,
		92496, 1, 4,
		92835, 1, 4,
		93174, 3, 4,
		93852, 2, 4,
		94191, 0, 4,
		94531, 0, 4,
		95209, 0, 4,
		95887, 2, 4,
		96565, 3, 4,
		96904, 0, 4,
		97243, 0, 4,
		97921, 0, 4,
		98261, 2, 4,
		98600, 3, 4,
		99278, 2, 4
	};
	
	public static int[] SMOOOOCH_5 = {
		1958, 0, 4,
		2128, 3, 8,
		2297, 1, 4,
		4332, 0, 4,
		4671, 0, 4,
		4840, 3, 8,
		5010, 1, 4,
		7045, 0, 4,
		7384, 3, 4,
		7723, 1, 4,
		9757, 0, 4,
		10775, 3, 4,
		11114, 0, 4,
		11453, 0, 4,
		12131, 2, 4,
		12470, 3, 4,
		12809, 0, 4,
		13148, 3, 4,
		13487, 2, 4,
		13826, 1, 4,
		14165, 0, 4,
		14505, 3, 4,
		14844, 1, 4,
		15183, 2, 4,
		15522, 0, 4,
		15861, 3, 4,
		16200, 2, 4,
		16539, 1, 4,
		16878, 0, 4,
		17217, 3, 4,
		17556, 2, 4,
		17895, 1, 4,
		18235, 0, 4,
		18574, 3, 4,
		18913, 1, 4,
		19252, 2, 4,
		19591, 3, 4,
		19930, 0, 4,
		20269, 2, 4,
		20608, 1, 4,
		20947, 3, 4,
		21286, 0, 4,
		21626, 2, 4,
		21965, 1, 4,
		22304, 0, 4,
		22643, 1, 4,
		22982, 0, 4,
		23321, 1, 4,
		23660, 0, 4,
		23999, 3, 4,
		24338, 2, 4,
		24677, 1, 4,
		25016, 3, 4,
		25356, 0, 4,
		25695, 2, 4,
		26034, 1, 4,
		26373, 0, 4,
		26712, 3, 4,
		27051, 2, 4,
		27390, 1, 4,
		27729, 0, 4,
		28068, 3, 4,
		28407, 2, 4,
		28746, 1, 4,
		29086, 0, 4,
		29425, 3, 4,
		29764, 2, 4,
		30103, 1, 4,
		30442, 0, 4,
		30781, 1, 4,
		31120, 2, 4,
		31459, 1, 4,
		31798, 2, 4,
		32137, 0, 4,
		32646, 1, 8,
		32985, 2, 8,
		33324, 3, 8,
		33494, 2, 4,
		33833, 1, 4,
		34172, 3, 4,
		34511, 0, 4,
		34850, 3, 4,
		35528, 1, 4,
		35867, 0, 4,
		36207, 3, 4,
		36885, 1, 4,
		37224, 0, 4,
		37563, 3, 4,
		38241, 1, 4,
		38580, 0, 4,
		38919, 3, 4,
		39597, 1, 4,
		39937, 0, 4,
		40276, 3, 4,
		40954, 1, 4,
		41293, 0, 4,
		41632, 3, 4,
		42310, 1, 4,
		42649, 3, 4,
		42988, 0, 4,
		43667, 1, 4,
		44006, 3, 4,
		45023, 2, 4,
		45362, 1, 4,
		45701, 0, 4,
		46040, 2, 4,
		46379, 1, 4,
		46718, 3, 4,
		47057, 3, 4,
		47397, 3, 4,
		47736, 2, 4,
		48075, 1, 4,
		48414, 0, 4,
		48753, 2, 4,
		49092, 1, 4,
		49431, 0, 4,
		49770, 2, 4,
		49940, 0, 8,
		50109, 1, 4,
		50448, 0, 4,
		50787, 1, 4,
		51127, 0, 4,
		51466, 2, 4,
		51805, 1, 4,
		52144, 0, 4,
		52483, 2, 4,
		52653, 0, 8,
		52822, 1, 4,
		53161, 0, 4,
		53500, 3, 4,
		53839, 1, 4,
		54857, 3, 4,
		55874, 2, 4,
		56213, 3, 4,
		56552, 1, 4,
		58587, 0, 4,
		59943, 0, 4,
		61299, 0, 4,
		62656, 0, 4,
		64012, 3, 4,
		65368, 3, 4,
		65708, 3, 4,
		66386, 0, 4,
		66725, 2, 4,
		67064, 0, 4,
		67403, 0, 4,
		67742, 3, 4,
		69099, 3, 4,
		69438, 0, 4,
		70455, 3, 4,
		70794, 0, 4,
		71811, 0, 4,
		72150, 3, 4,
		73168, 0, 4,
		73507, 3, 4,
		74524, 3, 4,
		74863, 0, 4,
		75202, 0, 4,
		75541, 2, 4,
		75880, 1, 4,
		76219, 1, 4,
		76559, 0, 4,
		76898, 1, 4,
		77237, 2, 4,
		77576, 1, 4,
		77745, 0, 8,
		77915, 0, 4,
		78254, 3, 4,
		78593, 2, 4,
		78932, 1, 4,
		79271, 3, 4,
		79610, 0, 4,
		79950, 1, 4,
		80289, 2, 4,
		80628, 0, 4,
		80967, 3, 4,
		81306, 1, 4,
		81645, 2, 4,
		81984, 3, 4,
		82323, 0, 4,
		82662, 1, 4,
		83001, 2, 4,
		83340, 0, 4,
		83680, 3, 4,
		84019, 2, 4,
		84358, 1, 4,
		84697, 0, 4,
		85036, 3, 4,
		85375, 1, 4,
		85714, 2, 4,
		86053, 0, 4,
		86392, 1, 4,
		86731, 2, 4,
		87070, 1, 4,
		87410, 0, 4,
		87749, 0, 4,
		87918, 0, 8,
		88088, 0, 4,
		88427, 2, 4,
		88766, 1, 4,
		89105, 0, 4,
		89444, 2, 4,
		89783, 1, 4,
		90122, 0, 4,
		90461, 3, 4,
		90801, 2, 4,
		91140, 1, 4,
		91479, 1, 4,
		91818, 0, 4,
		92157, 2, 4,
		92496, 1, 4,
		92835, 1, 4,
		93174, 3, 4,
		93513, 1, 4,
		93852, 2, 4,
		94191, 0, 4,
		94531, 0, 4,
		94870, 1, 4,
		95209, 0, 4,
		95717, 3, 8,
		95887, 2, 4,
		96226, 1, 4,
		96565, 3, 4,
		96904, 0, 4,
		97243, 0, 4,
		97582, 1, 4,
		97921, 0, 4,
		98261, 2, 4,
		98600, 3, 4,
		98939, 0, 4,
		99278, 2, 4
	};
	
	public static int[] SMOOOOCH_7 = {
		1958, 0, 4,
		2128, 3, 8,
		2297, 2, 4,
		2636, 3, 4,
		3314, 0, 4,
		4332, 0, 4,
		4671, 0, 4,
		4840, 3, 8,
		5010, 2, 4,
		5349, 3, 4,
		6027, 0, 4,
		7045, 0, 4,
		7384, 3, 4,
		7723, 2, 4,
		8062, 2, 4,
		8740, 0, 4,
		9757, 0, 4,
		10435, 3, 4,
		10775, 3, 4,
		11114, 0, 4,
		11453, 0, 4,
		12131, 2, 4,
		12470, 3, 4,
		12640, 1, 8,
		12809, 3, 4,
		12979, 1, 8,
		13148, 2, 4,
		13487, 0, 4,
		13826, 1, 4,
		14165, 0, 4,
		14335, 2, 8,
		14505, 1, 4,
		14844, 3, 4,
		15183, 2, 4,
		15522, 0, 4,
		15691, 2, 8,
		15861, 1, 4,
		16200, 3, 4,
		16539, 2, 4,
		16878, 3, 4,
		17048, 1, 8,
		17217, 2, 4,
		17556, 0, 4,
		17895, 1, 4,
		18235, 0, 4,
		18404, 1, 8,
		18574, 2, 4,
		18913, 3, 4,
		19252, 1, 4,
		19591, 3, 4,
		19760, 1, 8,
		19930, 2, 4,
		20269, 0, 4,
		20608, 1, 4,
		20947, 0, 4,
		21117, 1, 8,
		21286, 2, 4,
		21626, 3, 4,
		21965, 1, 4,
		22304, 0, 4,
		22643, 3, 4,
		22982, 1, 4,
		23151, 3, 8,
		23491, 0, 8,
		23660, 3, 4,
		23830, 1, 8,
		23999, 2, 4,
		24338, 0, 4,
		24677, 1, 4,
		25016, 0, 4,
		25186, 1, 8,
		25356, 2, 4,
		25695, 3, 4,
		26034, 1, 4,
		26373, 3, 4,
		26542, 1, 8,
		26712, 2, 4,
		27051, 0, 4,
		27390, 1, 4,
		27729, 0, 4,
		27899, 1, 8,
		28068, 2, 4,
		28407, 3, 4,
		28746, 1, 4,
		29086, 3, 4,
		29255, 2, 8,
		29425, 1, 4,
		29764, 0, 4,
		30103, 2, 4,
		30442, 3, 4,
		30781, 1, 4,
		31120, 3, 4,
		31459, 2, 4,
		31798, 1, 4,
		32137, 0, 4,
		32307, 3, 8,
		32646, 0, 8,
		32816, 1, 4,
		32985, 0, 8,
		33324, 0, 8,
		33494, 3, 4,
		33833, 0, 4,
		34172, 1, 4,
		34341, 2, 8,
		34511, 0, 4,
		34850, 2, 4,
		35189, 0, 4,
		35528, 3, 4,
		35867, 3, 4,
		36207, 1, 4,
		36546, 3, 4,
		36885, 0, 4,
		37224, 0, 4,
		37563, 2, 4,
		37902, 0, 4,
		38241, 3, 4,
		38580, 0, 4,
		38919, 1, 4,
		39258, 0, 4,
		39597, 3, 4,
		39937, 3, 4,
		40276, 2, 4,
		40615, 3, 4,
		40954, 0, 4,
		41293, 3, 4,
		41632, 2, 4,
		41971, 3, 4,
		42310, 0, 4,
		42649, 0, 4,
		42988, 2, 4,
		43327, 0, 4,
		43667, 3, 4,
		44006, 0, 4,
		45023, 3, 4,
		45362, 0, 4,
		45701, 1, 4,
		46040, 2, 4,
		46210, 1, 8,
		46379, 2, 4,
		46718, 3, 4,
		47057, 3, 4,
		47227, 1, 8,
		47397, 1, 4,
		47736, 3, 4,
		48075, 0, 4,
		48414, 1, 4,
		48753, 2, 4,
		48922, 1, 8,
		49092, 2, 4,
		49431, 0, 4,
		49770, 1, 4,
		49940, 0, 8,
		50109, 2, 4,
		50279, 0, 8,
		50448, 1, 4,
		50787, 0, 4,
		51127, 1, 4,
		51466, 2, 4,
		51635, 1, 8,
		51805, 2, 4,
		52144, 0, 4,
		52483, 1, 4,
		52653, 0, 8,
		52822, 2, 4,
		52992, 0, 8,
		53161, 1, 4,
		53500, 3, 4,
		53839, 2, 4,
		54178, 2, 4,
		54857, 3, 4,
		55874, 1, 4,
		56043, 2, 8,
		56213, 3, 4,
		56552, 2, 4,
		56891, 2, 4,
		57569, 0, 4,
		58587, 0, 4,
		58926, 0, 4,
		59943, 0, 4,
		60282, 0, 4,
		61299, 0, 4,
		61638, 0, 4,
		62656, 0, 4,
		62995, 3, 4,
		64012, 3, 4,
		64351, 3, 4,
		65368, 3, 4,
		65708, 3, 4,
		66386, 1, 4,
		66725, 3, 4,
		67064, 0, 4,
		67403, 2, 4,
		67742, 3, 4,
		68759, 3, 4,
		69099, 3, 4,
		69438, 0, 4,
		70116, 3, 4,
		70455, 3, 4,
		70794, 0, 4,
		71472, 0, 4,
		71811, 0, 4,
		72150, 3, 4,
		72829, 3, 4,
		73168, 3, 4,
		73507, 0, 4,
		74185, 3, 4,
		74524, 3, 4,
		74863, 0, 4,
		75202, 3, 4,
		75541, 2, 4,
		75880, 1, 4,
		76050, 2, 8,
		76219, 2, 4,
		76559, 0, 4,
		76898, 0, 4,
		77237, 1, 4,
		77406, 2, 8,
		77576, 1, 4,
		77745, 0, 8,
		77915, 3, 4,
		78084, 1, 8,
		78254, 2, 4,
		78593, 0, 4,
		78932, 1, 4,
		79271, 0, 4,
		79441, 2, 8,
		79610, 1, 4,
		79950, 3, 4,
		80289, 2, 4,
		80628, 3, 4,
		80797, 1, 8,
		80967, 2, 4,
		81306, 0, 4,
		81645, 1, 4,
		81984, 0, 4,
		82154, 1, 8,
		82323, 2, 4,
		82662, 3, 4,
		83001, 1, 4,
		83340, 3, 4,
		83510, 2, 8,
		83680, 1, 4,
		84019, 0, 4,
		84358, 2, 4,
		84697, 0, 4,
		84866, 1, 8,
		85036, 2, 4,
		85375, 3, 4,
		85714, 1, 4,
		86053, 0, 4,
		86392, 2, 4,
		86731, 1, 4,
		86901, 1, 8,
		87070, 2, 4,
		87410, 1, 4,
		87749, 0, 4,
		87918, 0, 8,
		88088, 0, 4,
		88427, 2, 4,
		88766, 0, 4,
		89105, 1, 4,
		89444, 2, 4,
		89614, 1, 8,
		89783, 2, 4,
		90122, 3, 4,
		90292, 1, 8,
		90461, 2, 4,
		90801, 0, 4,
		91140, 1, 4,
		91479, 0, 4,
		91818, 1, 4,
		92157, 2, 4,
		92326, 1, 8,
		92496, 2, 4,
		92835, 1, 4,
		93174, 1, 4,
		93513, 2, 4,
		93683, 1, 8,
		93852, 2, 4,
		94191, 0, 4,
		94531, 3, 4,
		94700, 2, 8,
		94870, 3, 4,
		95209, 2, 4,
		95717, 0, 8,
		95887, 3, 4,
		96226, 0, 4,
		96565, 1, 4,
		96904, 0, 4,
		97243, 3, 4,
		97413, 2, 8,
		97582, 3, 4,
		97921, 2, 4,
		98261, 0, 4,
		98600, 3, 4,
		98939, 0, 4,
		99278, 2, 4
	};
	
	public static int[] SMOOOOCH_9 = {
		1789, 0, 8,
		3314, 0, 4,
		3654, 3, 4,
		3823, 2, 8,
		3993, 3, 4,
		4501, 0, 8,
		4671, 3, 4,
		5688, 3, 4,
		6027, 0, 4,
		6366, 3, 4,
		6536, 2, 8,
		6705, 3, 4,
		7214, 0, 8,
		7384, 3, 4,
		8401, 3, 4,
		8570, 3, 8,
		8740, 3, 4,
		8910, 1, 8,
		9079, 2, 4,
		9418, 2, 4,
		10096, 3, 4,
		11114, 3, 4,
		11283, 3, 8,
		11622, 0, 8,
		12131, 0, 4,
		12300, 2, 8,
		12470, 0, 4,
		12809, 0, 4,
		13148, 2, 4,
		13487, 0, 4,
		13826, 1, 4,
		13996, 2, 8,
		14165, 3, 4,
		14335, 2, 8,
		14505, 1, 4,
		14844, 0, 4,
		15013, 1, 8,
		15183, 0, 4,
		15352, 2, 8,
		15522, 3, 4,
		15691, 1, 8,
		15861, 2, 4,
		16200, 0, 4,
		16370, 2, 8,
		16539, 0, 4,
		16709, 1, 8,
		16878, 3, 4,
		17048, 2, 8,
		17217, 1, 4,
		17556, 0, 4,
		17726, 1, 8,
		17895, 0, 4,
		18065, 2, 8,
		18235, 3, 4,
		18404, 2, 8,
		18574, 1, 4,
		18913, 0, 4,
		19082, 1, 8,
		19252, 0, 4,
		19421, 2, 8,
		19591, 0, 4,
		19760, 2, 8,
		19930, 1, 4,
		20269, 3, 4,
		20439, 1, 8,
		20608, 3, 4,
		20778, 2, 8,
		20947, 0, 4,
		21117, 1, 8,
		21286, 2, 4,
		21626, 3, 4,
		21795, 2, 8,
		21965, 3, 4,
		22134, 1, 8,
		22304, 0, 4,
		22473, 2, 8,
		22643, 1, 4,
		22982, 3, 4,
		23151, 1, 8,
		23321, 3, 4,
		23660, 1, 4,
		23999, 1, 4,
		24169, 3, 8,
		24338, 1, 4,
		24508, 3, 8,
		24847, 2, 8,
		25016, 3, 4,
		25186, 2, 8,
		25356, 1, 4,
		25695, 0, 4,
		25864, 1, 8,
		26034, 0, 4,
		26203, 2, 8,
		26373, 0, 4,
		26542, 1, 8,
		26712, 2, 4,
		27051, 3, 4,
		27221, 2, 8,
		27390, 3, 4,
		27560, 1, 8,
		27729, 3, 4,
		27899, 2, 8,
		28068, 1, 4,
		28407, 0, 4,
		28577, 1, 8,
		28746, 0, 4,
		28916, 2, 8,
		29086, 3, 4,
		29255, 1, 8,
		29425, 2, 4,
		29764, 0, 4,
		29933, 2, 8,
		30103, 0, 4,
		30272, 1, 8,
		30442, 0, 4,
		30611, 2, 8,
		30781, 1, 4,
		31120, 3, 4,
		31290, 1, 8,
		31459, 3, 4,
		31798, 0, 4,
		32137, 1, 4,
		32307, 3, 8,
		32476, 2, 4,
		32646, 1, 8,
		32816, 0, 4,
		33155, 1, 4,
		33494, 1, 4,
		33663, 2, 8,
		34002, 3, 8,
		34341, 1, 8,
		34681, 3, 8,
		34850, 1, 4,
		35189, 0, 4,
		35528, 2, 4,
		35698, 0, 8,
		35867, 0, 4,
		36037, 1, 8,
		36207, 2, 4,
		36546, 1, 4,
		36715, 2, 8,
		36885, 3, 4,
		37054, 0, 8,
		37224, 3, 4,
		37393, 2, 8,
		37563, 1, 4,
		37902, 2, 4,
		38072, 1, 8,
		38241, 0, 4,
		38411, 3, 8,
		38580, 3, 4,
		38750, 2, 8,
		38919, 1, 4,
		39258, 2, 4,
		39428, 1, 8,
		39597, 0, 4,
		39767, 3, 8,
		39937, 0, 4,
		40106, 1, 8,
		40276, 2, 4,
		40615, 1, 4,
		40784, 2, 8,
		40954, 3, 4,
		41123, 0, 8,
		41293, 0, 4,
		41462, 1, 8,
		41632, 2, 4,
		41971, 1, 4,
		42141, 2, 8,
		42310, 3, 4,
		42480, 0, 8,
		42649, 0, 4,
		42819, 1, 8,
		42988, 2, 4,
		43327, 1, 4,
		43497, 2, 8,
		43667, 3, 4,
		43836, 0, 8,
		44006, 0, 4,
		44175, 2, 8,
		44345, 1, 4,
		44684, 2, 4,
		44853, 1, 8,
		45023, 3, 4,
		45362, 1, 4,
		46210, 2, 8,
		46379, 0, 4,
		46718, 0, 4,
		47057, 1, 4,
		47227, 3, 8,
		47397, 1, 4,
		47566, 2, 8,
		47736, 0, 4,
		48075, 0, 4,
		48414, 0, 4,
		48753, 2, 4,
		49092, 1, 4,
		49431, 0, 4,
		49770, 1, 4,
		49940, 3, 8,
		50109, 1, 4,
		50279, 2, 8,
		50448, 0, 4,
		50787, 0, 4,
		51127, 1, 4,
		51296, 0, 8,
		51466, 2, 4,
		51635, 1, 8,
		51805, 2, 4,
		52144, 0, 4,
		52483, 1, 4,
		52653, 3, 8,
		52822, 1, 4,
		52992, 2, 8,
		53161, 0, 4,
		53500, 0, 4,
		53839, 1, 4,
		54009, 0, 8,
		54178, 2, 4,
		54348, 1, 8,
		54518, 2, 4,
		54857, 3, 4,
		55026, 1, 8,
		55196, 2, 4,
		55535, 2, 4,
		56213, 3, 4,
		56891, 1, 4,
		57230, 0, 4,
		57400, 1, 8,
		57569, 3, 4,
		57739, 1, 8,
		57908, 2, 4,
		58248, 2, 4,
		58926, 3, 4,
		59943, 3, 4,
		60113, 3, 8,
		60282, 0, 4,
		61299, 0, 4,
		61469, 0, 8,
		61638, 0, 4,
		62656, 0, 4,
		62825, 0, 8,
		62995, 3, 4,
		64012, 3, 4,
		64182, 3, 8,
		64351, 0, 4,
		65368, 0, 4,
		65538, 0, 8,
		65708, 3, 4,
		66725, 3, 4,
		66894, 3, 8,
		67064, 3, 4,
		67403, 2, 4,
		67573, 3, 8,
		67742, 2, 4,
		68081, 3, 4,
		68420, 2, 4,
		68759, 0, 4,
		69099, 2, 4,
		69438, 0, 4,
		69607, 1, 8,
		69946, 0, 8,
		70455, 0, 4,
		70624, 2, 8,
		70794, 0, 4,
		70964, 0, 8,
		71303, 0, 8,
		71811, 0, 4,
		71981, 2, 8,
		72150, 0, 4,
		72320, 0, 8,
		72659, 3, 8,
		73168, 3, 4,
		73337, 2, 8,
		73507, 3, 4,
		73676, 3, 8,
		74015, 0, 8,
		74524, 0, 4,
		74694, 2, 8,
		74863, 0, 4,
		75033, 0, 8,
		75372, 0, 8,
		75880, 0, 4,
		76050, 2, 8,
		76219, 0, 4,
		76389, 0, 8,
		76559, 0, 4,
		76728, 3, 8,
		76898, 0, 4,
		77237, 0, 4,
		77576, 3, 4,
		77915, 1, 4,
		78254, 2, 4,
		78424, 1, 8,
		78593, 2, 4,
		78763, 1, 8,
		78932, 3, 4,
		79102, 2, 8,
		79271, 3, 4,
		79441, 2, 8,
		79610, 1, 4,
		79950, 0, 4,
		80119, 1, 8,
		80289, 0, 4,
		80458, 2, 8,
		80628, 0, 4,
		80797, 2, 8,
		80967, 1, 4,
		81306, 3, 4,
		81475, 1, 8,
		81645, 3, 4,
		81815, 2, 8,
		81984, 0, 4,
		82154, 1, 8,
		82323, 2, 4,
		82662, 3, 4,
		82832, 2, 8,
		83001, 3, 4,
		83171, 1, 8,
		83340, 0, 4,
		83510, 2, 8,
		83680, 1, 4,
		84019, 3, 4,
		84188, 1, 8,
		84358, 3, 4,
		84527, 2, 8,
		84697, 3, 4,
		84866, 1, 8,
		85036, 2, 4,
		85375, 0, 4,
		85545, 2, 8,
		85714, 0, 4,
		85884, 1, 8,
		86053, 3, 4,
		86223, 2, 8,
		86392, 1, 4,
		86731, 0, 4,
		86901, 1, 8,
		87070, 0, 4,
		87410, 0, 4,
		87749, 0, 4,
		88088, 1, 4,
		88427, 0, 4,
		88766, 0, 4,
		89105, 0, 4,
		89275, 0, 8,
		89444, 0, 4,
		89783, 2, 4,
		90122, 0, 4,
		90461, 1, 4,
		90631, 3, 8,
		90801, 1, 4,
		90970, 2, 8,
		91140, 0, 4,
		91479, 3, 4,
		91648, 2, 8,
		91818, 1, 4,
		92157, 0, 4,
		92326, 1, 8,
		92496, 0, 4,
		92835, 0, 4,
		93174, 1, 4,
		93344, 3, 8,
		93513, 1, 4,
		93683, 2, 8,
		93852, 0, 4,
		94191, 0, 4,
		94531, 1, 4,
		94700, 0, 8,
		94870, 1, 4,
		95039, 2, 8,
		95209, 3, 4,
		95548, 0, 4,
		95887, 1, 4,
		96056, 3, 8,
		96226, 0, 4,
		96565, 2, 4,
		97074, 3, 8,
		97243, 1, 4,
		97582, 0, 4,
		97921, 2, 4,
		98261, 0, 4,
		98600, 1, 4,
		98769, 3, 8,
		98939, 0, 4,
		99278, 2, 4,
		99617, 0, 4,
		99956, 2, 4,
		100126, 2, 8,
		100295, 0, 4,
		100465, 2, 8,
		100634, 0, 4,
		100804, 0, 8,
		102160, 0, 8,
		103517, 3, 8
	};
	
	public static int[] SMOOOOCH_DATA = NotesData.SMOOOOCH_5_MOD;
	
	public static string DIFFICULTY_EASY = "Easy";
	public static string DIFFICULTY_MEDIUM = "Medium";
	public static string DIFFICULTY_HARD = "Hard";
	public static string DIFFICULTY_LEVEL = DIFFICULTY_EASY;
		
}