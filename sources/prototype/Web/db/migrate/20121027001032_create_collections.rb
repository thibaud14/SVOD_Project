class CreateCollections < ActiveRecord::Migration
  def change
    create_table :collections do |t|
      t.string :nom
      t.integer :year

      t.timestamps
    end
  end
end
