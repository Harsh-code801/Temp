public static List<List<Document>> CreateBatches(List<Document> documents, int maxBatchSize)
{
    var familyGroups = documents
        .GroupBy(doc => doc.FamilyId)
        .ToList();

    var batches = new List<List<Document>>();
    var currentBatch = new List<Document>();
    int currentBatchSize = 0;

    foreach (var family in familyGroups)
    {
        var familyDocs = family.ToList();
        int familySize = familyDocs.Sum(d => d.Size);

        // Case 1: Family doesn't fit, and current batch has documents → flush current batch
        if (currentBatchSize + familySize > maxBatchSize && currentBatch.Count > 0)
        {
            batches.Add(currentBatch);
            currentBatch = new List<Document>();
            currentBatchSize = 0;
        }

        // Case 2: Family still doesn't fit (even in empty batch) → let it break the limit, but isolate it
        if (familySize > maxBatchSize)
        {
            batches.Add(familyDocs); // its own batch
        }
        else
        {
            currentBatch.AddRange(familyDocs);
            currentBatchSize += familySize;
        }
    }

    if (currentBatch.Count > 0)
    {
        batches.Add(currentBatch);
    }

    return batches;
}
